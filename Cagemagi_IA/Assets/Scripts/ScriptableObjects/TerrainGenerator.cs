using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/TerrainGenerator")]
public class TerrainGenerator : ScriptableObject
{
public GameObject cubePrefab; // Arrastra un prefab de cubo a este campo en el Inspector
public int gridWidth = 7;
public int gridHeight = 16;
public float spacing = 1.0f;
public float probability = 0.8f; // Variable para controlar la probabilidad de generación de un bloque
public void GenerateGrid(Vector3 position)
{
    if (cubePrefab == null)
    {
        Debug.LogError("Cannot instantiate a null object!");
        return;
    }
    // Calcula la posición inicial
    Vector3 startPos = position;

    // Genera la cuadrícula
    for (int x = 0; x < gridWidth; x++)
    {
        for (int y = 0; y < gridHeight; y++)
        {
            Vector3 pos = startPos + Vector3.right * x * spacing - Vector3.forward * y * spacing;
            float randomValue = Random.value; // Obtiene un valor aleatorio entre 0 y 1
            if (randomValue > probability) // Si el valor aleatorio es mayor a la probabilidad establecida
            {
                Instantiate(cubePrefab, pos, Quaternion.identity);
            }
        }
    }
}
}