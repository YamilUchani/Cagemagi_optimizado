using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTerrain : MonoBehaviour
{
public TerrainGenerator pasto;
void Start()
{
    pasto.GenerateGrid();
}
}