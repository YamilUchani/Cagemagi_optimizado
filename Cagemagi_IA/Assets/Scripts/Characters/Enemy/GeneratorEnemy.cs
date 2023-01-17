using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
public GameObject enemyPrefab;
public EnemyMover movement;
public CollisionDetector detector;
public EnemyGenerator troncocas; // variable para almacenar el ScriptableObject
public float speed = 1f; // variable para controlar la velocidad de movimiento del objeto
public Vector3 spawnPosition = new Vector3(0, 4, 20); // variable para controlar la posición de spawn del objeto
public float destroyPosition = -20f;
public LayerMask targetLayer;
public float detectionRadius = 0.5f; // variable para controlar el radio de detección
public Vector3 spherefrontposition; // variable para controlar la altura de la esfera
    
private void Start()
{
    troncocas = ScriptableObject.CreateInstance<EnemyGenerator>();
    troncocas.enemyPrefab = enemyPrefab;
    troncocas.movement = movement;
    troncocas.detector = detector;
    troncocas.speed = speed;
    troncocas.destroyPosition = destroyPosition;
    troncocas.targetLayer = targetLayer;
    troncocas.detectionRadius = detectionRadius;
    troncocas.spherefrontposition = spherefrontposition;
    troncocas.Spawn(spawnPosition); // generar un nuevo objeto
    
}
}