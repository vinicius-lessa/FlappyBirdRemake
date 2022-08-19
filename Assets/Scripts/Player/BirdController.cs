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
 *  60fps
 *      -2         + 5             * 1          * 0.017             = 0.051 (1 seg = 3.06)
 *      position.x + movimentSpeed * horizontal * Time.deltaTime;
 *  10fps
 *      -2         + 5             * 1          * 0.1 	            = 0.3 (1 seg = 3)
 *      position.x + movimentSpeed * horizontal * Time.deltaTime;
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Player Components
    private Rigidbody2D rb;
    private float jumpForce = 7f;

    // Start is called before the first frame update
    void Start()
    {
        // Fazendo Cashing do Método GET COMPONENT para o processamento ficar mais leve a cada frame
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentSpeed = 3f; // Units (Default: meter)
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

        // JUMPING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMPING");
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
