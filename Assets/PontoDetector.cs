using UnityEngine;

public class PontoDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Acha o GameHandler e soma 1 ponto
            FindObjectOfType<GameHandler>().AdicionarPonto();
        }
    }
}
