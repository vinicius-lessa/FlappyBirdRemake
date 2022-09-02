/**
* File DOC
* 
* @Description Script gerencia as acoes dos botoes na tela de GameOver.
* 
* @ChangeLog 
*   - Gabriel Shirai - 08/23/2022: Criacao do script para controle dos botoes na tela de GameOver.
*   - Vinícius Lessa - 09/01/2022: Implementation of the method AnimateGOScreen(), responsible for activating and animating the Game Over Screen (This).
* 
* @ Tips & Tricks: 
* 
*
**/

using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen Instance { get; private set; } // Self Instance    

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        // Debug.Log(gameObject.GetComponent<RectTransform>().rect.position);
    }
    
    public void AnimateGOScreen()
    {
        GameObject GOPanel      = gameObject.transform.GetChild(0).gameObject;
        Vector3 panelStartPos   = GOPanel.transform.position;
        float panelHeight       = GOPanel.GetComponent<RectTransform>().sizeDelta.y;
        
        GOPanel.SetActive(true);

        RectTransform panelRect = GOPanel.GetComponent<RectTransform>();
        Canvas canvas = FindObjectOfType<Canvas>();

        panelRect.localPosition =
            new Vector3(
                panelRect.localPosition.x,
                Camera.main.transform.position.y - (canvas.GetComponent<RectTransform>().rect.height / 2 + (GOPanel.GetComponent<RectTransform>().sizeDelta.y / 2)),
                panelRect.localPosition.z
            );

        // Animations
        panelRect.transform.DOMove(panelStartPos, 1f).SetEase(Ease.InOutQuint);
    }

    public void RestartGame()
    {
        AudioListener.volume = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}