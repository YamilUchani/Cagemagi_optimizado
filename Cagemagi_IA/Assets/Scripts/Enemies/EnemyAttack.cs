using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    public int delayattack;
    private float timer;
    public EnemyCollision col;
    public GameObject model;
    private void Update() 
    {
       if(col.terrain != null && col.mov.collision)
        {
            if(!col.terrain.CompareTag("Vacio"))
            {
                TerrainLife lifeComponent = col.terrain.GetComponent<TerrainLife>();
                timer += Time.deltaTime;
                if (timer >= delayattack)
                {
                    lifeComponent.life -= damage;
                    timer = 0f;
                }
            }
        }
    }
}
