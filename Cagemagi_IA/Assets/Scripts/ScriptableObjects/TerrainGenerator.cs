using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/TerrainGenerator")]
public class TerrainGenerator : ScriptableObject
{
    public GameObject cubePrefab; // Arrastra un prefab de cubo a este campo en el Inspector
    public int gridWidth = 16;
    public int gridHeight = 7;
    public float spacing = 1.0f;

    public void GenerateGrid(Vector3 position)
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cannot instantiate a null object!");
            return;
        }
        // Calcula la posición inicial
        Vector3 startPos = position - (Vector3.right * (gridWidth - 1) * spacing / 2) - (Vector3.forward * (gridHeight - 1) * spacing / 2);

        // Genera la cuadrícula
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 pos = startPos + Vector3.right * x * spacing + Vector3.forward * y * spacing;
                Instantiate(cubePrefab, pos, Quaternion.identity);
            }
        }
    }
}