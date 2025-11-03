using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject canoDuploPrefab;
    [SerializeField] private GameObject posicaoChao;
    [SerializeField] private GameObject posicaoTeto;

    [SerializeField] private float intervaloSpawn = 2f; // tempo entre spawns
    private float tempoDesdeUltimoSpawn = 0f;

    private bool jogoAtivo = true;

    void Update()
    {
        // Se o jogo acabou, não faz mais nada
        if (!jogoAtivo) return;

        // Verifica se o jogador saiu do mapa
        if (VerificarForaDoMapa())
        {
            GameOver();
            return;
        }

        // Controla o spawn dos canos
        tempoDesdeUltimoSpawn += Time.deltaTime;

        if (tempoDesdeUltimoSpawn >= intervaloSpawn)
        {
            SpawnCano();
            tempoDesdeUltimoSpawn = 0f;
        }
    }

    private void SpawnCano()
    {
        float minY = posicaoChao.transform.position.y + 2f;
        float maxY = posicaoTeto.transform.position.y - 2f;
        float yAleatorio = Random.Range(minY, maxY) -1.5f;

        GameObject novoCano = Instantiate(canoDuploPrefab);
        novoCano.transform.position = new Vector3(10f, yAleatorio, 0f);
    }

    private bool VerificarForaDoMapa()
    {
        var jogador = PlayerFlappyBird.Instance.transform.position.y;

        return (jogador > posicaoTeto.transform.position.y || jogador < posicaoChao.transform.position.y);
    }

    public void GameOver()
    {
        // Impede que seja chamado várias vezes
        if (!jogoAtivo) return;

        jogoAtivo = false;
        Debug.Log("GAME OVER");
        PlayerFlappyBird.Instance.GameOver();
    }
}