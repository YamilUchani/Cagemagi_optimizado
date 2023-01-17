using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public float detectionRadius; // variable para controlar el radio de detección
    public Vector3 spherefrontposition; // variable para controlar la altura de la esfera
    public LayerMask targetLayer; // variable para seleccionar la capa del objeto a detectar
    public EnemyMover enemyMover; // variable para almacenar el componente EnemyMover del objeto
    private bool isDetected = false; // variable para controlar si se ha detectado un objeto
    private void Start()
    {
    enemyMover = GetComponent<EnemyMover>(); // almacenar el componente EnemyMover del objeto en la variable
    }

    private void Update()
    {
        // detectar si hay un objeto en el rango de detección con el radio, centro y altura especificados
        Collider[] colliders = Physics.OverlapSphere(transform.position + spherefrontposition,detectionRadius, targetLayer);
        if (colliders.Length > 0)
        {
            enemyMover.speed = 0f; // detener el movimiento del objeto
            isDetected = true; // cambiar el estado de la variable a true
            transform.position=new Vector3(transform.position.x,transform.position.y,(int)transform.position.z);
        }
        else if (isDetected) // si se ha detectado un objeto previamente
        {
            enemyMover.speed = 1f; // reanudar el movimiento del objeto
            isDetected = false; // cambiar el estado de la variable a false
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + spherefrontposition, detectionRadius);
    }
}