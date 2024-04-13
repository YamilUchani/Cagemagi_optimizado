using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRegenerate : MonoBehaviour
{
    public int delayregenerate;
    private int contadorPasto;
    public List<GameObject> objectsInTrigger = new List<GameObject>();
    TerrainCreate regenerate;
    TerrainCreate regenerateTerrain;
    public int i = 0;
    float timer = 0f;
    private void OnTriggerStay(Collider other)
    {
        // Verificar si el GameObject en contacto tiene el tag "Vacio" y no está en la lista
        if (other.CompareTag("Vacio") && !objectsInTrigger.Contains(other.gameObject))
        {
            regenerate = other.gameObject.GetComponent<TerrainCreate>();
            if(!regenerate.enemyCol)
            {
                objectsInTrigger.Add(other.gameObject);
            }

        }
        else if (other.CompareTag("Pasto") )
        {
            TowerAbsorb towerAbsorb = this.GetComponent<TowerAbsorb>();
            if(!towerAbsorb.objectsInTrigger.Contains(other.gameObject))
            {
                towerAbsorb.objectsInTrigger.Add(other.gameObject);
            }
        }
    }
    private void Update() 
    {
        
        
        objectsInTrigger.RemoveAll(item => item == null);
        objectsInTrigger.RemoveAll(go => go.CompareTag("Pasto"));
        if(0<objectsInTrigger.Count)
        {
            timer += Time.deltaTime;
            regenerateTerrain = objectsInTrigger[0].GetComponent<TerrainCreate>();
            if(!regenerateTerrain.enemyCol)
            {
                if (timer >= delayregenerate)
                {
                    
                    regenerateTerrain.Regenerate();
                    timer = 0f;
                }
            }
            else
            {
                timer = 0f;
            }
        }

    }
}
