using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBottom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GeneratorTower targetObject;
    public string targetFunctionName;
    public string targetFunctionCreate;
    public bool repeatContinuously = false;
    public bool isButtonHeld = false;
    public UIMana mana;
    public int TypeTower;
    public int manaCost;
    private void Update()
    {
        if (isButtonHeld)
        {
            // Ejecutar la función en el objeto objetivo si el proceso se repite continuamente
            if (repeatContinuously)
            {
                targetObject.TypeTower = TypeTower;
                targetObject.SendMessage(targetFunctionName);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
            isButtonHeld = true;
            // Ejecutar la función en el objeto objetivo una vez si el proceso no se repite continuamente
            if (!repeatContinuously)
            {
                targetObject.TypeTower = TypeTower;
                targetObject.SendMessage(targetFunctionName);
            }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(targetObject.selectTower);
        targetObject.selectTower = null;
        isButtonHeld = false;
        if (mana.valor>=manaCost)
        {
            targetObject.TypeTower = TypeTower;
            targetObject.SendMessage(targetFunctionCreate);
        }
    }
}
