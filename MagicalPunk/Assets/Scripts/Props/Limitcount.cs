using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Limitcount : MonoBehaviour
{
    public int Enemycount;
    private void OnCollisionEnter(Collision other)
    {
        // Comprobamos si el GameObject con el que colisionamos tiene la etiqueta "Limite"
        if (other.gameObject.CompareTag("Enemigo"))
        {
            // Destruimos el GameObject actual al que está adjunto este script
            Destroy(other.gameObject);
            Enemycount++;
            
        }
    }
    private void Update() 
    {
        if (Enemycount > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }     
    }

}
