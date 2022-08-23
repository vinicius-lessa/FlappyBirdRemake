/**
* File DOC
* 
* @Description Script de gerenciamento da animação do Cenário (Background e chão).
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do Arquivo e documentação de cabeçalho. 
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingTexture : MonoBehaviour
{
    // Float
    public float backgroundSpeed;

    // Components
    public Renderer backgroundRenderer;

    public void Start()
    {
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver)
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
        }
    }
}
