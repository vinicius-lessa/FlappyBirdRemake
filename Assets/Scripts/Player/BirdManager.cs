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
        if (col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("Floor"))
        {
            if (!GameManager.Instance.gameOver){
                GameManager.Instance.GameOver();
            }            
        }
    }
}
