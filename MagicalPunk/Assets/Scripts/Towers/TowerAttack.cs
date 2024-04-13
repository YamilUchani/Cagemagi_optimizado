using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject prefabAtaque; // El prefab del objeto que quieres generar
    private GameObject enemytarget;
    public Vector3 position;
    private float timer;
    public int speed = 2;
    public float height = 2f; // La altura de la parábola.
    private bool hasAttacked = false; // Bandera para verificar si ya se generó el ataque
    public int delayattack = 3;
    public int damage = 2;
    private void Update() 
    {
        if (hasAttacked)
        {
            
            timer += Time.deltaTime;
            if(enemytarget == null)
            {
                hasAttacked = false;
            }
            if (timer >= delayattack)
            {
                GameObject proyectattack = Instantiate(prefabAtaque, transform.position + position, Quaternion.identity);
                ProyecImpact attackkproyect = proyectattack.AddComponent<ProyecImpact>();
                attackkproyect.speed = speed;
                attackkproyect.targetObject = enemytarget;
                timer = 0f;
            }
            
        }    

    }
    private void OnTriggerStay(Collider other)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player" (puedes cambiarlo al tag que desees)
        if (other.CompareTag("Enemigo") && !hasAttacked)
        {
            enemytarget = other.gameObject;     
            hasAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que salió del collider es el enemigo con el que se generó el ataque
        if (other.gameObject == enemytarget)
        {
            hasAttacked = false; // Restablecer la bandera a false para permitir nuevos ataques cuando entre otro enemigo
            enemytarget = null;
        }
    }
}
