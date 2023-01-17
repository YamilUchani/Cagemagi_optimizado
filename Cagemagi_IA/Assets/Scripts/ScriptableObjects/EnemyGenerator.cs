using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/EnemyGenerator")]
public class EnemyGenerator : ScriptableObject
{
public GameObject enemyPrefab; // variable para almacenar el prefab a generar
public EnemyMover movement; // variable para almacenar el script a integrar al prefab generado
public CollisionDetector detector;
public float speed = 1f; // variable para controlar la velocidad de movimiento del objeto
public float destroyPosition = -20f; // variable para controlar la posición en la que el objeto debe ser destruido
public LayerMask targetLayer;
public float detectionRadius; // variable para controlar el radio de detección
public Vector3 spherefrontposition; // variable para controlar la altura de la esfera
public void Spawn(Vector3 spawnPosition)
{
    
    GameObject spawnedObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    spawnedObject.AddComponent(movement.GetType()); // agregar el script al objeto generado
    spawnedObject.AddComponent(detector.GetType());
    spawnedObject.GetComponent<EnemyMover>().speed = speed; // asignar la velocidad al componente EnemyMover del objeto generado
    spawnedObject.GetComponent<EnemyMover>().destroyPosition = destroyPosition;
    spawnedObject.GetComponent<CollisionDetector>().targetLayer = targetLayer;
    spawnedObject.GetComponent<CollisionDetector>().detectionRadius = detectionRadius;
    spawnedObject.GetComponent<CollisionDetector>().spherefrontposition = spherefrontposition;
}
}