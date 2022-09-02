/**
* File DOC
* 
* @Description Script de controle do Player
* @ChangeLog 
*   - Vinícius Lessa - 08/19/2022: Criação do arquivo e documentação de cabeçalho. Início da captação de comandos via teclado e movimentação do Objeto.
*   - Vinícius Lessa - 08/20/2022: Mudança da variável 'jumpForce' para Publica.
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

using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Player Components
    private Rigidbody2D rb;
    float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Cashing do Método GET COMPONENT para o processamento ficar mais leve a cada frame
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // JUMPING
        if (!GameManager.Instance.gameOver){
            if (Input.GetKeyDown(KeyCode.Space)){
                jumpForce = 7f;
            }
        }
    }
    
    void FixedUpdate()
    {
        if (jumpForce > 0){
            rb.velocity = Vector2.up * jumpForce;
            jumpForce   = 0;
        }
    }
}