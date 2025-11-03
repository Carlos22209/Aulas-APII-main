using TMPro;
using UnityEngine;

public class TesteBC : MonoBehaviour
{
    private TextMeshProUGUI TextoDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        TextoDisplay = GetComponent<TextMeshProUGUI>();
        TextoDisplay.text = "TESTE";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
