/**
* File DOC
* 
* @Description Script de controle do Player
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Movimentação do objeto GameManager.
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}