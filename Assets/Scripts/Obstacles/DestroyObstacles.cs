/**
* File DOC
* 
* @Description Script que destr�i os Obst�culos (Pipes).
* 
* @ChangeLog 
*   - Vin�cius Lessa - 08/22/2022: Implementa��o da destrui��o dos Gameobjects (pipes) ap�s sa�rem da cena.
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
