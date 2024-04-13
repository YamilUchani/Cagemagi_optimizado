using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICost : MonoBehaviour
{
    public Button myButton;
    public GameObject UImana;
    public int valorLimite;

    private void Update()
    {
        UIMana mana = UImana.GetComponent<UIMana>();
        // Asegurarse de que el botón está inicialmente habilitado o inhabilitado según el valor
        if (mana.valor>=valorLimite)
        {
            myButton.interactable = true; // Habilitar el botón
        }
        else
        {
            myButton.interactable = false; // Inhabilitar el botón
        }
    }
}
