using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLife : MonoBehaviour
{
    public int manaCount;
    public int life;
    public int lifeTotal;
    public string terrainTag;
    public GameObject towerDetected;
    private bool hasExecuted = false;
    private void Update()
    {
        if (transform.childCount > 12)
        {
            if (!hasExecuted)
            {
                lifeTotal = life;
                
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Torre"))
                    {
                        towerDetected = child.gameObject;
                    }
                }
                life = towerDetected.GetComponent<TowerLife>().life;
                hasExecuted = true;
            }
            towerDetected.GetComponent<TowerLife>().life = life;
        }
        else
        {
            if (hasExecuted)
            {
                life = lifeTotal;
                hasExecuted = false;
            }
            if (life<=0)
            {
                this.gameObject.tag = "Vacio";
                var createComponent = gameObject.AddComponent<TerrainCreate>();
                Collider collider = gameObject.GetComponent<Collider>();
                foreach (Transform childTransform in gameObject.transform) childTransform.gameObject.SetActive(false);
                createComponent.manaCount = manaCount;
                collider.isTrigger = true;
                createComponent.terrainTag = terrainTag;
                createComponent.life = 20; 
                TerrainLife terrainLife = GetComponent<TerrainLife>();
                Destroy(terrainLife);
            }
        }
        
    }
}
