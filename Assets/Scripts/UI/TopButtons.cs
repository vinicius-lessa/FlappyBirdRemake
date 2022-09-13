/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Tratativa para que os botões de Mute/Unmute e Play/Pause tornem-se funcionais. Também adicionado a opção de teclas referentes as ações (P e M).
*   - Vinícius Lessa - 08/30/2022: Ajuste no bug de posicionamento do Botão "Mute" ao se iniciar o estado de "Play" do game.
*   - Vinícius Lessa - 08/33/2022: Implementação do Método GameOverActivated(), responsável por reaizar animações no GUI GameOver Screen.
* 
* @ Tips & Tricks:
*
**/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TopButtons : MonoBehaviour
{
    public static TopButtons Instance { get; private set; } // Self Instance

    // Sprites (for the buttons)
    // Mute/Unmute
    public Sprite s_MutedSprite;
    public Sprite s_UnmutedSprite;
    
    // Play/Pause
    public Sprite s_PausedSprite;
    public Sprite s_PlayingSprite;
    
    // Buttons
    public Button b_MuteUnmute;
    public Button b_PausePlay;

    // GameObject
    public GameObject gameOverPanel;

    // Vars
    private bool isMuted = false;
    private bool isPaused = false;
    private Vector3 goPanelStartPos;

    private void Awake() {
        Instance = this;
    }    

    private void Start() {
        goPanelStartPos = gameOverPanel.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && GameManager.Instance.gameStarted)
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleVolume();
        }
    }

    // Mute/Unmute the Game
    public void ToggleVolume()
    {        
        b_MuteUnmute.image.sprite = (isMuted ? s_UnmutedSprite : s_MutedSprite);
        AudioListener.volume = (isMuted ? 1 : 0);
        
        isMuted = (isMuted ? isMuted = false : isMuted = true);        
    }        
    
    // Pause/Play the Game
    public void TogglePause()
    {
        b_PausePlay.image.sprite = (isPaused ? s_PlayingSprite : s_PausedSprite);
        AudioListener.pause = (isPaused ? false : true);
        Time.timeScale = (isPaused ? 1 : 0);
        
        isPaused = (isPaused ? isPaused = false : isPaused = true);
    }

    public void GameOverActivated() // Called by Game Manager
    {
        GameOverScreen.Instance.AnimateGOScreen();
        AnimateScore();
    }

    private void AnimateScore(){        
        
        b_PausePlay.gameObject.SetActive(false); // Disable Pause Button

        GameObject o_ChildScore = transform.GetChild(1).gameObject;
        // float scoreOffset       = gameOverPanel.GetComponent<RectTransform>().position.y + gameOverPanel.GetComponent<RectTransform>().sizeDelta.y / 2; // Aways above GameOver Panel
        float scoreOffset       = gameOverPanel.GetComponent<RectTransform>().position.y; // Aways above GameOver Panel
        float scoreBiggerMult   = 1.6f;

        // Score Text - Position
        o_ChildScore.GetComponent<RectTransform>().transform.DOMove(
            new Vector3(o_ChildScore.transform.position.x, goPanelStartPos.y, o_ChildScore.transform.position.z),
            1f).SetEase(Ease.InOutQuint);
        
        // Score Text - Scale
        o_ChildScore.transform.DOScale(
            new Vector3(o_ChildScore.transform.localScale.x * scoreBiggerMult, o_ChildScore.transform.localScale.y * scoreBiggerMult, o_ChildScore.transform.localScale.z),
            1f).SetEase(Ease.InOutQuint);
    }
}