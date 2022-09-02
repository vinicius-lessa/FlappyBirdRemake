/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Movimentação do objeto GameManager.
*   - Vinícius Lessa - 08/22/2022: Tratativa para chamar GameOver após colisão. Após GameOver, o Freeze X do BirdPlayer Object é desabilitado.
*   - Vinícius Lessa - 08/26/2022: Mudança do objeto a ser ativado que terá como filhos os GameObjects Score e Botões no topo da tela.
*   - Vinícius Lessa - 08/31/2022: Implementações na componentização da lógica do GameOver, agora tratativas específicas são feitas na Classe 'TopButton'.
* 
* @ Tips & Tricks:
*
**/

using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // Self Instance
    public static GameManager Instance { get; private set; }

    // GameObjects
    public GameObject o_Player;
    public GameObject o_TopElements;
    public GameObject o_GameOverScreen;    

    // Text
    public TextMeshProUGUI o_Score;
    public TextMeshProUGUI o_textStart;

    // GameOver / Levels
    [HideInInspector]
    public bool gameOver;
    [HideInInspector]
    public bool gameStarted = false;

    // Components
    private SpawnObstacles spawnObstacles;

    // Common Variables
    public float cameraSpeed;
    private int score = 0;


    private void Awake()
    {
        o_textStart.gameObject.SetActive(true);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles = GetComponent<SpawnObstacles>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start the Game
        if (!gameStarted && !gameOver){
            if (Input.GetKeyUp(KeyCode.Space))
            {
                o_Player.GetComponent<Rigidbody2D>().gravityScale = 2f;
                
                // Component (Script)
                spawnObstacles.enabled = true;
                
                // GameObj                
                o_textStart.gameObject.SetActive(false);

                // Keep Top Elemenst Align
                o_TopElements.gameObject.transform.Find("ScoreText").gameObject.SetActive(true);
                o_TopElements.gameObject.transform.Find("PauseButton").gameObject.SetActive(true);                

                gameStarted = true;

                // TopButtons.Instance.b_MuteUnmute.gameObject.GetComponent<LayoutGroup>() ;
            }
        }

        // Camera Movement
        if (!gameOver)
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);            
        }
    }

    public void IncreaseScore()
    {
        if (!gameOver){
            score++;
            o_Score.text = score.ToString();
        }
    }

    public void GameOver()
    {
        // State Update
        gameOver    = true;
        gameStarted = false;

        o_Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; // Cleans "Freeze Rotation X"

        TopButtons.Instance.GameOverActivated(); // GUI GameOver Animation
    }
}