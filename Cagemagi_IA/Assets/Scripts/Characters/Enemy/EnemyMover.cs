using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 1f; // variable para controlar la velocidad de movimiento del objeto
    public float destroyPosition = -20f; // variable para controlar el limite destruccion de objeto
    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // mover el objeto hacia atrás según la velocidad y el tiempo transcurrido

        if (transform.position.z <= destroyPosition) // si la posición en el eje Z es menor al límite de destrucción
        {
            Destroy(gameObject); // destruir el objeto
        }
    }
}