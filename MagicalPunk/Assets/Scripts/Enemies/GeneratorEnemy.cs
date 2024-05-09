using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    public float delaygenerate;
    private float timer;
    private float delay;
    public GameObject time;
    private Vector3 spawnpos;
    private float delayinitial = 30;
    private void Start()
    {
        delay = delaygenerate;
        delaygenerate = delayinitial;
        time = GameObject.FindGameObjectWithTag("Tiempo");   
        
    }
    private void Update() 
    {
        timer += Time.deltaTime;
        if (timer >= delaygenerate)
        {
            spawnpos= new Vector3 (Random.Range(0, 5), 0.48f, 20f);
            enemyGenerator.Spawn(spawnpos); // Generar un nuevo objeto
            timer = 0f;
            delaygenerate = delay;
        }
        UITime UITime = time.GetComponent<UITime>();
        UITime.valor = (int)(delayinitial-timer);
    }
}
