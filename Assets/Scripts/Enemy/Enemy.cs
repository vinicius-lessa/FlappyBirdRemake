/**
* File DOC
* 
* @Description Script que gerencia as Instâncias dos Obstáculos
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/20/2022: Criação do Arquivo e documentação de cabeçalho. Instanciação dos Prefabs no GameLevel Scene e cálculos iniciais de distância geral.
* 
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // GameObjects
    public GameObject pipePrefab;    

    private Vector2 currentPosition;
    private float eixoX = 10;
    
    void Start()
    {
    }

    // ### CODE STARTS
    void OnEnable()
    {
        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        var eixoY = Random.Range(4f, 8f);

        var topPipe     = Instantiate(pipePrefab, new Vector2(eixoX, eixoY), Quaternion.identity);
        var bottomPipe  = Instantiate(pipePrefab, new Vector2(eixoX, eixoY -11), Quaternion.identity);

        eixoX += 7;

        var xPipePosition = topPipe.transform.position.x;

        while ( !(xPipePosition <= transform.position.x + 5) )
        {
            yield return new WaitForSeconds(.01f);
            Debug.Log(transform.position.x);
        };

        yield return SpawnPipes();
    }

    void Update()
    {
        currentPosition = transform.position;        
    }
}