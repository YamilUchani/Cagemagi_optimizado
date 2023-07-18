using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/TowerGenerator")]
public class TowerGenerator : ScriptableObject
{
    private GameObject towerContainer; // Variable para almacenar el contenedor
    public GameObject towerPrefab;
    public string towerTag;
    public string towerLayer;
    public int delayregenerate;
    public int delayaction; //Variable que define la velocidad de regeneracion de pasto
    public int typeTower;
    public int life;
    public int manaCost;
    public void GenerateTower(GameObject spawnedTerrain)
    {
        if(typeTower == 1)
        {
            if (spawnedTerrain.transform.childCount == 0)
            {
                GameObject spawnedTower = Instantiate(towerPrefab);
                spawnedTower.tag = towerTag;
                int layer = LayerMask.NameToLayer(towerLayer);
                spawnedTower.layer = layer;
                spawnedTower.transform.SetParent(spawnedTerrain.transform);
                spawnedTower.transform.localPosition = new Vector3(0f,5.5f,0f);
                var lifeComponent = spawnedTower.AddComponent<TowerLife>();
                var regenerateComponent = spawnedTower.AddComponent<TowerRegenerate>();
                var absorbComponent = spawnedTower.AddComponent<TowerAbsorb>();
                lifeComponent.life = life;
                regenerateComponent.delayregenerate = delayregenerate;
                absorbComponent.delayabsorb = delayaction;
            }
        }
    }
}
