using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/EnemyGenerator")]
public class EnemyGenerator : ScriptableObject
{
    private GameObject spawnedContainer; // Variable para almacenar el contenedor
    public GameObject enemyPrefab;
    public float speed;
    public float torque;
    public string enemyTag;
    public float destroyPosition;
    public float rayLength;
    public float rayHeight;
    public int damage;
    public int delayattack;
    public string objectTag;
    public string limitTag;

    public void Spawn(Vector3 spawnPosition)
    {
        if (spawnedContainer == null) // Comprueba si el contenedor ya existe
        {
            spawnedContainer = new GameObject("EnemyContainer");
        }

        GameObject spawnedModel = new GameObject("EnemyModel");
        spawnedModel.tag = enemyTag;
        GameObject spawnedObject = Instantiate(enemyPrefab);
        spawnedObject.tag = enemyTag;
        spawnedModel.transform.position = spawnPosition;
        spawnedModel.transform.SetParent(spawnedContainer.transform);
        spawnedObject.transform.SetParent(spawnedModel.transform);
        spawnedObject.transform.localPosition = Vector3.zero;
        
        var moverComponent = spawnedModel.AddComponent<EnemyMover>();
        var detectorComponent = spawnedModel.AddComponent<EnemyCollision>();
        var attackComponent = spawnedModel.AddComponent<EnemyAttack>();
        CapsuleCollider collider = spawnedObject.AddComponent<CapsuleCollider>();
        collider.height = 1.15f;
        collider.radius = 0.5f;
        collider.center = new Vector3(0f, 0f, 0f);
        moverComponent.speed = speed;
        moverComponent.torque = torque;
        moverComponent.destroyPosition = destroyPosition;
        moverComponent.model = spawnedObject;
        detectorComponent.rayLength = rayLength;
        detectorComponent.rayHeight = rayHeight;
        detectorComponent.mov = moverComponent;
        detectorComponent.objectTag = objectTag;
        detectorComponent.limitTag = limitTag;
        attackComponent.damage = damage;
        attackComponent.delayattack = delayattack;
        attackComponent.col = detectorComponent;
        attackComponent.model = spawnedObject;
    }
}
