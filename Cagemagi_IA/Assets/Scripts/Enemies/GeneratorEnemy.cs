using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    public float delaygenerate;
    private float timer;
    private float delay;
    private Vector3 spawnpos;

    private void Start()
    {
        delay = delaygenerate;
        delaygenerate = 60;
    }
    private void Update() 
    {
        timer += Time.deltaTime;
        if (timer >= delaygenerate)
        {
            spawnpos= new Vector3 (Random.Range(0, 9), 0.48f, 20f);
            enemyGenerator.Spawn(spawnpos); // Generar un nuevo objeto
            timer = 0f;
            delaygenerate = delay;
        }
    }
}
