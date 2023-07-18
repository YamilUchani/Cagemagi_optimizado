using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;

public class GeneratorTower : MonoBehaviour
{
    
    public TowerGenerator towerGenerator;
    public Camera mainCamera; 
    public GameObject UImana;
    private Vector3 touchPosition;
    private GameObject hitObject;
    public GameObject selectTower;
    public UIMana mana;
    private RaycastHit hit;
    private void Start() 
    {
        mana = UImana.GetComponent<UIMana>();
    }
    public void towerPosition()
    {
        hitObject = null;
        touchPosition = Input.GetTouch(0).position;
        Ray ray = mainCamera.ScreenPointToRay(touchPosition);
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~LayerMask.GetMask("IgnoreTouch")))
        {
            hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Vacio") || hitObject.CompareTag("Pasto"))
            {
                if (selectTower == null) // Comprueba si el contenedor ya existe
                {
                    selectTower = Instantiate(towerGenerator.towerPrefab);
                    
                }
                Component[] components = selectTower.GetComponentsInChildren<Component>();
                foreach (Component component in components)
                {
                    if (!(component is MeshRenderer) && !(component is MeshFilter) && !(component is Transform))
                    {
                        Destroy(component);
                    }
                }
                selectTower.transform.position = hitObject.transform.position + new Vector3(0f,1.1f,0f);
            }
        }
    }
    public void towerCreate()
    {
        
        UIMana mana = UImana.GetComponent<UIMana>();
        if (hit.collider != null)
        {
            if (hitObject.CompareTag("Pasto"))
            {
                towerGenerator.GenerateTower(hitObject);
                
                mana.valor -= towerGenerator.manaCost;
                
            }
            else if (hitObject.CompareTag("Vacio"))
            {
                TerrainCreate regenerateTerrain = hitObject.GetComponent<TerrainCreate>();
                regenerateTerrain.Regenerate();
                towerGenerator.GenerateTower(hitObject);
                Debug.Log("sdasdasdasdasd");
            }
        }
    }
}
