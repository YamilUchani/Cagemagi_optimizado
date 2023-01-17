using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTerrain : MonoBehaviour
{
public GameObject cubePrefab;
public TerrainGenerator pasto;
public int gridWidth = 9;
public int gridHeight = 16;
public float spacing = 1.0f;

public float probability = 0.8f;
public Vector3 initialposition = new Vector3(0,0,0);
void Start()
{
    pasto = ScriptableObject.CreateInstance<TerrainGenerator>();
    pasto.cubePrefab = cubePrefab;
    pasto.gridWidth = gridWidth;
    pasto.gridHeight = gridHeight;
    pasto.spacing = spacing;
    pasto.probability = probability;
    pasto.GenerateGrid(initialposition);
}
}