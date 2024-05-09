using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator/TerrainGenerator")]
public class TerrainGenerator : ScriptableObject
{
public int manaCount;
private GameObject terrainContainer;
public GameObject cubePrefab; // Arrastra un prefab de cubo a este campo en el Inspector
public Material voidMaterial;
public Material pastoMaterial;
public UIMana UImana;
public string terrainTag;
public int gridWidth = 18;
public int gridHeight = 9;
public int life;
private float spacing = 1f;
public float probability; // Variable para controlar la probabilidad de generación de un bloque

public void GenerateGrid()
{
    if (terrainContainer == null) // Comprueba si el contenedor ya existe
    {
        terrainContainer = new GameObject("TerrainContainer");
    }
    // Calcula la posición inicial
    Vector3 startPos = new Vector3(0,0,0);

    // Genera la cuadrícula
    for (int y = 0; y < gridWidth; y++)
    {
        for (int x = 0; x < gridHeight; x++)
        {
            Vector3 pos = startPos + Vector3.right * x * spacing - Vector3.forward * y * spacing;
            float randomValue = Random.value; // Obtiene un valor aleatorio entre 0 y 1
            if (randomValue > probability) // Si el valor aleatorio es mayor a la probabilidad establecida
            {
                
                GameObject spawnedTerrain = Instantiate(cubePrefab, pos, Quaternion.identity);
                spawnedTerrain.transform.SetParent(terrainContainer.transform);
                spawnedTerrain.tag = terrainTag;
                var collComponent = spawnedTerrain.AddComponent<BoxCollider>();
                var lifeComponent = spawnedTerrain.AddComponent<TerrainLife>();
                var manaComponent = spawnedTerrain.AddComponent<TerrainMana>();
                collComponent.size = new Vector3(1f, 1f, 1f);
                collComponent.center = new Vector3(0f, 0f, 0f);
                lifeComponent.life = life;
                lifeComponent.voidMaterial = voidMaterial;
                lifeComponent.terrainTag = terrainTag;
                lifeComponent.pastoMaterial = pastoMaterial;
                lifeComponent.manaCount = manaCount;
                manaComponent.manaCount = manaCount;

            }
            else
            {
                GameObject spawnedTerrain = Instantiate(cubePrefab, pos, Quaternion.identity);
                spawnedTerrain.transform.SetParent(terrainContainer.transform);
                foreach (Transform childTransform in spawnedTerrain.transform) childTransform.gameObject.SetActive(false);
                var collComponent = spawnedTerrain.AddComponent<BoxCollider>();
                var creaComponent = spawnedTerrain.AddComponent<TerrainCreate>();
                collComponent.size = new Vector3(1f, 1f, 1f);
                collComponent.center = new Vector3(0f, 0f, 0f);
                collComponent.isTrigger = true;
                creaComponent.terrainTag = terrainTag;
                creaComponent.pastoMaterial = pastoMaterial;
                creaComponent.life = life; 
                creaComponent.voidMaterial = voidMaterial; 
                creaComponent.manaCount = manaCount;
                spawnedTerrain.tag = "Vacio";
            }
        }
    }
}
}