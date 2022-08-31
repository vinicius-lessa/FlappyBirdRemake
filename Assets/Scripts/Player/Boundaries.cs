/**
 * File DOC
 * 
 * @Description Script de controle do Player
 * @ChangeLog 
 *  - Vin�cius Lessa - 08/19/2022: Cria��o do arquivo e documenta��o de cabe�alho.
 * 
 * @ Tips & Tricks: 
 *      - Script Based on: https://youtu.be/ailbszpt_AI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{    
    private Vector2 screenBounds;
    private float objectSilhouette = .7f;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    
    void LateUpdate()
    {
        Vector2 newPosition = transform.position;
        // newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x + objectSilhouette, screenBounds.x - objectSilhouette);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y + objectSilhouette, screenBounds.y + 4 - objectSilhouette);
        transform.position = newPosition;
    }
}