using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLife : MonoBehaviour
{
    public int manaCount;
    public int life;
    public int lifeTotal;
    public Material voidMaterial;
    public string terrainTag;
    public Material pastoMaterial;
    public GameObject towerDetected;
    private bool hasExecuted = false;
    private void Update()
    {
        if (transform.childCount == 1)
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
                Renderer renderer = gameObject.GetComponent<Renderer>();
                var createComponent = gameObject.AddComponent<TerrainCreate>();
                Collider collider = gameObject.GetComponent<Collider>();
                createComponent.manaCount = manaCount;
                collider.isTrigger = true;
                createComponent.terrainTag = terrainTag;
                renderer.material = voidMaterial;
                createComponent.pastoMaterial = pastoMaterial;
                createComponent.life = 20; 
                createComponent.voidMaterial = voidMaterial; 
                TerrainLife terrainLife = GetComponent<TerrainLife>();
                Destroy(terrainLife);
            }
        }
        
    }
}
