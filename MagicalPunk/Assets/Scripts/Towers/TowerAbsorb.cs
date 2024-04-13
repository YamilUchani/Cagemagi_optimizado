using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAbsorb : MonoBehaviour
{
    public GameObject mana;
    public List<GameObject> objectsInTrigger = new List<GameObject>();
    float timer = 0f;
    public float delayabsorb;
    private void Start() 
    {
        mana = GameObject.FindGameObjectWithTag("Mana");   
    }
    void Update()
    {
        objectsInTrigger.RemoveAll(item => item == null);
        objectsInTrigger.RemoveAll(go => go.CompareTag("Vacio"));
        timer += Time.deltaTime;
        if (timer >= delayabsorb)
        {
            foreach (GameObject objectsVariable in objectsInTrigger)
            {
                TerrainMana objectsMana = objectsVariable.GetComponent<TerrainMana>();
                UIMana UImana = mana.GetComponent<UIMana>();
                UImana.valor += objectsMana.manaCount;
            }
            timer = 0f;
        }
    }
}
