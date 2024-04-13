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
    public Vector3 position;
    public GameObject proyectile;
    public void GenerateTower(GameObject spawnedTerrain)
    {
        if(typeTower == 0)
        {
                GameObject spawnedTower = Instantiate(towerPrefab);
                spawnedTower.tag = towerTag;
                int layer = LayerMask.NameToLayer(towerLayer);
                spawnedTower.layer = layer;
                spawnedTower.transform.SetParent(spawnedTerrain.transform);
                spawnedTower.transform.localPosition = new Vector3(0f,0.25f,0f);
                var lifeComponent = spawnedTower.AddComponent<TowerLife>();
                var regenerateComponent = spawnedTower.AddComponent<TowerRegenerate>();
                var absorbComponent = spawnedTower.AddComponent<TowerAbsorb>();
                BoxCollider boxCollider = spawnedTower.AddComponent<BoxCollider>();
                boxCollider.isTrigger = true;
                boxCollider.center = new Vector3(0f, 0f, 0f);
                boxCollider.size = new Vector3(2f, 0.12f, 2f);
                Rigidbody rigidbody = spawnedTower.AddComponent<Rigidbody>();
                // Establecer las propiedades del Rigidbody
                rigidbody.mass = 1f;
                rigidbody.linearDamping = 0f;
                rigidbody.angularDamping = 0.05f;
                rigidbody.useGravity = false;
                rigidbody.isKinematic = false;
                rigidbody.interpolation = RigidbodyInterpolation.None;
                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

                // Congelar la posición y rotación del Rigidbody
                rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                lifeComponent.life = life;
                regenerateComponent.delayregenerate = delayregenerate;
                absorbComponent.delayabsorb = delayaction;
        }
        else if(typeTower == 1)
        {
                GameObject spawnedTower = Instantiate(towerPrefab);
                spawnedTower.tag = towerTag;
                int layer = LayerMask.NameToLayer(towerLayer);
                spawnedTower.layer = layer;
                spawnedTower.transform.SetParent(spawnedTerrain.transform);
                spawnedTower.transform.localPosition = new Vector3(0f,0.25f,0f);
                var attackComponent = spawnedTower.AddComponent<TowerAttack>();
                var lifeComponent = spawnedTower.AddComponent<TowerLife>();
                BoxCollider boxCollider = spawnedTower.AddComponent<BoxCollider>();
                boxCollider.isTrigger = true;
                boxCollider.center = new Vector3(0f, 0f, 0f);
                boxCollider.size = new Vector3(4f, 0.0313f, 4f);
                Rigidbody rigidbody = spawnedTower.AddComponent<Rigidbody>();
                // Establecer las propiedades del Rigidbody
                rigidbody.mass = 1f;
                rigidbody.linearDamping = 0f;
                rigidbody.angularDamping = 0.05f;
                rigidbody.useGravity = false;
                rigidbody.isKinematic = false;
                rigidbody.interpolation = RigidbodyInterpolation.None;
                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                lifeComponent.life = life;
                attackComponent.prefabAtaque = proyectile;
                attackComponent.position = position;
                attackComponent.delayattack = delayaction;
        }
    }
}
