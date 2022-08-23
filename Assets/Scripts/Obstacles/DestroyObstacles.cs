/**
* File DOC
* 
* @Description Script que destr�i os Obst�culos (Pipes).
* 
* @ChangeLog 
*   - Vin�cius Lessa - 08/22/2022: Implementa��o da destrui��o dos Gameobjects (pipes) ap�s sa�rem da cena.
*   - Gabriel Shirai - 08/23/2022: Mudanca total do metodo de destruicao do objeto (pipe) apos sairem da cena (baseando-se em distancia e nao em colisao)
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
    private void Update()
    {
        if (transform.position.x <= GameManager.Instance.transform.position.x - 15f)
        {
            Object.Destroy(gameObject);
        }
    }

}
