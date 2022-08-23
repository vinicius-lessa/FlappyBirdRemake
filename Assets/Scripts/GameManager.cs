/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Movimentação do objeto GameManager.
*   - Vinícius Lessa - 08/22/2022: Tratativa para chamar GameOver após colisão. Após GameOver, o Freeze X do BirdPlayer Object é desabilitado.
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Self Instance
    public static GameManager Instance { get; private set; }

    // GameObjects
    public GameObject o_Player;    
    public Text o_Score;

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
                // Component
                spawnObstacles.enabled = true;
                // GameObj
                o_Score.gameObject.SetActive(true);
                gameStarted = true;
            }
        }        

        // Camera Movement
        if (!gameOver && gameStarted)
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);            
        }
    }

    public void IncreaseScore()
    {
        if (!gameOver)
        {
            score++;
            o_Score.text = score.ToString();
            Debug.Log(score);
        }
    }

    public void GameOver()
    {
        // Debug.Log("GameOver Triggered!");
        gameOver = true;
        o_Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}