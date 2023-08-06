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
    public int life;
    public void Spawn(Vector3 spawnPosition)
    {
        if (spawnedContainer == null) // Comprueba si el contenedor ya existe
        {
            spawnedContainer = new GameObject("EnemyContainer");
        }

        GameObject spawnedModel = new GameObject("EnemyModel");
        spawnedModel.tag = enemyTag;
        GameObject spawnedObject = Instantiate(enemyPrefab);
        spawnedModel.transform.position = spawnPosition;
        spawnedModel.transform.SetParent(spawnedContainer.transform);
        spawnedObject.transform.SetParent(spawnedModel.transform);
        spawnedObject.transform.localPosition = Vector3.zero;
        
        var moverComponent = spawnedModel.AddComponent<EnemyMover>();
        var detectorComponent = spawnedModel.AddComponent<EnemyCollision>();
        var attackComponent = spawnedModel.AddComponent<EnemyAttack>();
        var lifeComponent = spawnedModel.AddComponent<EnemyLife>();
        CapsuleCollider collider = spawnedModel.AddComponent<CapsuleCollider>();
        Rigidbody rigidbody = spawnedModel.AddComponent<Rigidbody>();
        // Establecer las propiedades del Rigidbody
        rigidbody.mass = 1f;
        rigidbody.drag = 0f;
        rigidbody.angularDrag = 0.05f;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        rigidbody.interpolation = RigidbodyInterpolation.None;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        collider.isTrigger = false;
        collider.height = 2f;
        collider.radius = 0.45f;
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
        lifeComponent.life = life;
    }
}
