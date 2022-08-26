/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Tratativa para que os botões de Mute/Unmute e Play/Pause tornem-se funcionais. Também adicionado a opção de teclas referentes as ações (P e M).
* 
* @ Tips & Tricks:
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButtons : MonoBehaviour
{
    // Mute/Unmute
    public Sprite s_MutedSprite;
    public Sprite s_UnmutedSprite;
    
    // Play/Pause
    public Sprite s_PausedSprite;
    public Sprite s_PlayingSprite;
    
    // Buttons
    public Button b_MuteUnmute;
    public Button b_PausePlay;

    // Audio
    // public GameObject o_MainCamera;
    // public AudioListener AudioListenerComp;

    // Vars
    private bool isMuted = false;
    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        // AudioListenerComp = o_MainCamera.GetComponent<AudioListener>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
}
