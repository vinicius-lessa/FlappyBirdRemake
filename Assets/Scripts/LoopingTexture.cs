/**
* File DOC
* 
* @Description Script de gerenciamento da anima��o do Cen�rio (Background e ch�o).
* 
* @ChangeLog 
*   - Vin�cius Lessa - 08/19/2022: Cria��o do Arquivo e documenta��o de cabe�alho. 
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
