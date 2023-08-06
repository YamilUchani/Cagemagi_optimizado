using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyecImpact : MonoBehaviour
{
    public GameObject targetObject; // El GameObject al que quieres que se mueva el objeto actual.
    public float speed; // La velocidad a la que se moverá el objeto.
    public  int damage = 2;

    private void FixedUpdate()
    {
        // Mueve el objeto hacia el objetivo.
        if (targetObject != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, step);
            if(Mathf.Abs(transform.position.magnitude -targetObject.transform.position.magnitude) <= 0.15f)
            {
                EnemyLife lifeComponent = targetObject.GetComponent<EnemyLife>();   
                lifeComponent.life -= damage;
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
