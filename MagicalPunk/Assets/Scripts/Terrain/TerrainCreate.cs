using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreate : MonoBehaviour
{
    public int manaCount;
    public bool enemyCol;
    public string terrainTag;
    public int life;
    public Material voidMaterial;
    public Material pastoMaterial;
    public List<GameObject> objectsInTrigger = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            objectsInTrigger.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            objectsInTrigger.Remove(other.gameObject);
        }
    }
    private void Update() 
    {
        objectsInTrigger.RemoveAll(item => item == null);   
        if (objectsInTrigger.Count == 0)
        {
            enemyCol = false;
        }
        else
        {
            enemyCol = true;
        }
    }
    public void Regenerate()
    {
        gameObject.tag = terrainTag;
        Collider collider = gameObject.GetComponent<Collider>();
        var lifeComponent = gameObject.AddComponent<TerrainLife>();
        var manaComponent = gameObject.AddComponent<TerrainMana>();
        manaComponent.manaCount = manaCount;
        foreach (Transform childTransform in gameObject.transform) childTransform.gameObject.SetActive(true);
        collider.isTrigger = false;
        lifeComponent.life = life;
    }

}
