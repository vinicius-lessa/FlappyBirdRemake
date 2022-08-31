/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Tratativa para que os botões de Mute/Unmute e Play/Pause tornem-se funcionais. Também adicionado a opção de teclas referentes as ações (P e M).
*   - Vinícius Lessa - 08/30/2022: Ajuste no bug de posicionamento do Botão "Mute" ao se iniciar o estado de "Play" do game.
* 
* @ Tips & Tricks:
* 
*
**/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TopButtons : MonoBehaviour
{
    public static TopButtons Instance { get; private set; } // Self Instance

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
    public GameObject o_Score;

    // Vars
    private bool isMuted = false;
    private bool isPaused = false;

    private void Awake() {
        Instance = this;
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

    public void GameOverActivated()
    {
        b_PausePlay.gameObject.SetActive(false);

        Vector3 scorePosition = gameObject.transform.GetChild(1).gameObject.transform.position;                

        gameObject.transform.GetChild(1).gameObject.transform.DOMove(
            new Vector3(scorePosition.x, scorePosition.y - 380.0f, scorePosition.z), 
            1f).SetEase(Ease.InOutQuint);
    }
}
