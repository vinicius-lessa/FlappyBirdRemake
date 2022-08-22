/**
* File DOC
* 
* @Description Script que destrói os Obstáculos (Pipes).
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/22/2022: Implementação da destruição dos Gameobjects (pipes) após saírem da cena.
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pipe Hit the Player!!!");
        }

        if (col.gameObject.CompareTag("CollisionDestroyPipe"))
        {
            Destroy(this.gameObject);            
        }
    }

}
