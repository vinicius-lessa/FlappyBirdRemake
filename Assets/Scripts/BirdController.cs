/**
 * File DOC
 * 
 * @Description Script de controle do Player
 * @ChangeLog 
 *  - Vinícius Lessa - 08/19/2022: Criação do arquivo e documentação de cabeçalho. Início da captação de comandos via teclado e movimentação do Objeto.
 * 
 * @ Tips & Tricks: 
 *  What is Delta Time?
 *  Is a variable that Unity fills with the time it takes for a frame to be rendered
 *     
 *  1 second % FrameRate (example - Dt of 60Fps = 1 / 60 = 0.017f )
 *  Object Movement Example (starting X axis in 0)
 *  position.x + movimentSpeed * horizontal * Time.deltaTime;
 *  60fps
 *  EIXO X -> -2         + 5             * 1          * 0.017            = 0.051 (1 seg = 3.06)
 *  10fps
 *  EIXO X -> -2         + 5             * 1          * 0.1 	            = 0.3 (1 seg = 3)
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float movimentSpeed = 5f; // Units (Default: meter)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Debug.Log(horizontal);        

        Vector2 position = transform.position;
        
        // Units per Frame
        // position.x = position.x + movimentSpeed * horizontal;
        // position.y = position.y + movimentSpeed * vertical;

        // Units per second
        position.x = position.x + movimentSpeed * horizontal * Time.deltaTime; // Moviment Speed * Time to Render 1 Frame               
        position.y = position.y + movimentSpeed * vertical * Time.deltaTime;

        transform.position = position;
    }
}
