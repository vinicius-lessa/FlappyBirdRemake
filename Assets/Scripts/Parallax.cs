/**
* File DOC
* 
* @Date - 09/01/2022
* @Description This Script implements a Parallax effect in whatever GameObject it's attached to. It uses the camera position and the GameObject position as parameter to calculate the reposition.
* 
* @ChangeLog 
*   - Vinícius Lessa - 08/31/2022: Implementação inicial baseada em tutoriais. Necessário Revisão
* 
* @ Tips & Tricks:
*
**/

using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght; // Lenght of Sprite
    private float startPos; // Initial Position

    private Transform cam;

    [SerializeField]
    private float parallaxEffect;
    
    void Start()
    {
        startPos    = transform.position.x;
        cam         = Camera.main.transform;
        lenght      = GetComponent<SpriteRenderer>().bounds.size.x;
        // lenght      = transform.localScale.magnitude;
        
        Debug.Log(lenght);
    }
    
    void Update()
    {        
        // Parallax (X Axis)
        float distance      = cam.transform.position.x * parallaxEffect;        // Moves the object according to the Camera Position/Movement (left -n, right +n)
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // Reapeat
        float rePosition    = cam.transform.position.x * (1 - parallaxEffect);
        if (rePosition > startPos + lenght){ // Right
            startPos += lenght;
            // Time.timeScale = 0;

        } else if (rePosition < startPos - lenght){ // Left
            startPos -= lenght;

        }
    }
}
