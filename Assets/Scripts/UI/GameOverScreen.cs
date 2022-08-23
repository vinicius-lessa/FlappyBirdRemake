/**
* File DOC
* 
* @Description Script gerencia as acoes dos botoes na tela de GameOver.
*
* 
* @ChangeLog 
*   - Gabriel Shirai - 08/23/2022: Criacao do script para controle dos botoes na tela de GameOver.
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
