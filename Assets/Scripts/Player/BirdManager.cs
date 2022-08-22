using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // # GameOver
        if (collision.gameObject.CompareTag("Killer")){
            if (collision.transform.position.y >= (transform.position.y+0.8f)){ // Tentativa de corrigir bug de quebrar caixa mesmo batendo de lado quando a pedra está no ar                
                GameManager.GameOver();
                explode();
}
        }
}
