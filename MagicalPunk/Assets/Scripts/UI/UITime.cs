using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    public int valor = 0;
    public TMP_Text texto;
    public GameObject text;
    public GameObject imag;
    void Start() 
    {
        valor = 60;
    }
    void Update()
    {
        texto.SetText(valor.ToString());
        if(valor <= 0)
        {
            Color colorTexto = texto.color;
            colorTexto.a = 0f; // Establece el alfa a cero
            texto.color = colorTexto;
            Image imagen = imag.GetComponent<Image>();
            imagen.enabled = false;
            text.SetActive (false);
        }
    }
}