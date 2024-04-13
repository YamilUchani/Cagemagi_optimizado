using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    private void Update()
    {
        
        if(life<=0)
        {
            Destroy(gameObject);
        }
    }
}
