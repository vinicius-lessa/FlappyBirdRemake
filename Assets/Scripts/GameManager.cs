/**
* File DOC
* 
* @Description Script de gerenciamento do Player.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. Movimentação do objeto GameManager.
*   - Vinícius Lessa - 08/22/2022: Tratativa para chamar GameOver após colisão.
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

    public GameObject o_Player;

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