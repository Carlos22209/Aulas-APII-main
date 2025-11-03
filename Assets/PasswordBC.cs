using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PasswordBC : MonoBehaviour
{
    private string _senhaCorreta = "1234";
    private string _senhaAtual = "";

    [SerializeField] private TextMeshProUGUI displayText;
    
    private void UpdateDisplay()
    {
        displayText.text = _senhaAtual;
    }
    
    public void ClicouBotaoNumerico(int valor)
    {
        _senhaAtual += valor;
        UpdateDisplay();
    }
}
