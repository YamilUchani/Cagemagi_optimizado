using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;

public class GeneratorTower : MonoBehaviour
{
    public List<TowerGenerator> towerGenerator = new List<TowerGenerator>();
    public Camera mainCamera; 
    public GameObject UImana;
    private Vector3 touchPosition;
    private GameObject hitObject;
    public GameObject selectTower;
    public UIMana mana;
    private RaycastHit hit;
    public int TypeTower;
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
                    selectTower = Instantiate(towerGenerator[TypeTower].towerPrefab);
                    
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
                if (hitObject.transform.childCount == 0)
                {
                    towerGenerator[TypeTower].GenerateTower(hitObject);
                    mana.valor -= towerGenerator[TypeTower].manaCost;
                }                
            }
            else if (hitObject.CompareTag("Vacio"))
            {
                if(TypeTower == 0)
                {
                    TerrainCreate regenerateTerrain = hitObject.GetComponent<TerrainCreate>();
                    regenerateTerrain.Regenerate();
                    towerGenerator[TypeTower].GenerateTower(hitObject);
                    mana.valor -= towerGenerator[TypeTower].manaCost;
                }
            }
        }
    }
}
