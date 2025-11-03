using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Senha : MonoBehaviour
{
    public TextMeshProUGUI visor;
    public Image fundoVisor;

    int senhaCerta = 1234;
    int senhaAtual = 0;

    private void Start()
    {
        visor = GetComponent<TextMeshProUGUI>();
    }

    public void Tecla(int numero)
    {
        senhaAtual *= 10;
        senhaAtual += numero;
        AtualizarVisor();
    }

    public void Validar()
    {
        fundoVisor.color = senhaAtual == senhaCerta ? Color.blue : Color.red;   
    }

    private void AtualizarVisor()
    {
        if(senhaAtual == 0)
        {
            visor.text = "XXXX";
        }
        else
        {
            visor.text = senhaAtual.ToString();
        }
    }

    public void LimparSenha()
    {
        fundoVisor.color = Color.green;
        senhaAtual = 0;
        AtualizarVisor();
    }
}
