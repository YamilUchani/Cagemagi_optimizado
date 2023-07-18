using TMPro;
using UnityEngine;

public class UIMana : MonoBehaviour
{
    public int valor = 0;
    public TMP_Text texto;
    void Start()
    {
        valor=18;
        texto = GetComponent<TMP_Text>();
        texto.SetText(valor.ToString());
    }
    void Update()
    {
        texto.SetText(valor.ToString());
    }
}