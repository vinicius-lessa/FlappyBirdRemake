/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/31/2022: Criação da documentação de cabeçalho. Adicionado uso de Properties com relação a Classe GameManager. Verificação importante do estado do game para realizar próximos processamentos.
* 
* @ Tips & Tricks:
*
**/

using UnityEngine;

public class BirdManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // # HitPoint
        if ( col.gameObject.CompareTag("HitPoint") || (!GameManager.Instance.gameOver) ){
            GameManager.Instance.IncreaseScore();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // # GameOver
        if (col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("Ground"))
        {
            if (!GameManager.Instance.gameOver){
                GameManager.Instance.GameOver();
            }
        }
    }
}
