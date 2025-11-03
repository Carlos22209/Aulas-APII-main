using TMPro;
using UnityEngine;

public class TesteBotaoBC : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextoDisplay;
    
    public void ClicouBotao()
    {
        TextoDisplay.text = "Botao clicado";
    }
}
