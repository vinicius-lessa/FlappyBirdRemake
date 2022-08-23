using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // # HitPoint
        if ( col.gameObject.CompareTag("HitPoint") || (!GameManager.Instance.gameOver) )
        {
            GameManager.Instance.IncreaseScore();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // # GameOver
        if (col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("Floor"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
