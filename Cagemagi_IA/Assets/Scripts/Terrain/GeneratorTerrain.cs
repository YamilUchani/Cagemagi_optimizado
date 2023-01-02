using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTerrain : MonoBehaviour
{
    public GameObject cubePrefab;
    public TerrainGenerator pasto;

    void Start()
    {
        // Genera una nueva instancia de MyScriptableObject
        pasto = ScriptableObject.CreateInstance<TerrainGenerator>();
        pasto.cubePrefab = cubePrefab;
        pasto.gridWidth = 16;
        pasto.gridHeight = 7;
        pasto.spacing = 1.0f;
        pasto.GenerateGrid(new Vector3(0,0,0));
        
        
    }
}