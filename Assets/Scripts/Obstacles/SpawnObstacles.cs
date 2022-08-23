/**
* File DOC
* 
* @Description Script que gerencia as Instâncias dos Obstáculos.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/20/2022: Criação do Arquivo e documentação de cabeçalho. Instanciação dos Prefabs no GameLevel Scene e cálculos iniciais de distância geral.
*   - Vinícius Lessa - 08/22/2022: Ajustes no processo de Spawn com a variável do EixoX.
*   
* @ Tips & Tricks: 
* 
*
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles: MonoBehaviour
{
    // GameObjects
    public GameObject pipePrefab;
        
    private float pipeSpawnDistance = 11f; 

    void Awake()
    {        
    }

    void Start()
    {
        // gameManagerObj = GameObject.Find("GameManager");
    }

    // ### CODE STARTS
    void OnEnable()
    {
        StartCoroutine(SpawnPipes());
    }

    // Instantiates Pipes
    private IEnumerator SpawnPipes()
    {
        var eixoY = Random.Range(4f, 8f);
        var eixoX = transform.position.x + pipeSpawnDistance;

        var topPipe = Instantiate(pipePrefab, new Vector2(eixoX, eixoY), Quaternion.identity);        

        var xPipePosition = topPipe.transform.position.x;

        // Activates Next Spawn
        do
        {
            yield return new WaitForSeconds(.01f);
            continue;
        } while (!(xPipePosition <= transform.position.x + 5));

        yield return SpawnPipes();

    }
}