using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    // Referencias de posição
    [SerializeField] private GameObject posicaoTeto;
    [SerializeField] private GameObject posicaoChao;
    [SerializeField] private GameObject canoDuploPrefab;

    // Configurações do jogo
    [SerializeField] private float tempoSpawn = 2.5f;
    [SerializeField] private float offsetAltura = -1.5f;

    // Pontuação
    [SerializeField] private TextMeshProUGUI textoPontos;

    private float _tempoAtualSpawn;
    private int pontos = 0;
    private bool isGameOver = false;

    private void Start()
    {
        _tempoAtualSpawn = tempoSpawn;
        textoPontos.text = "0";
    }

    private void Update()
    {
        if (isGameOver) return;

        if (VerificarForaDoMapa())
        {
            PlayerFlappyBird.Instance.GameOver();
            isGameOver = true;
            return;
        }

        SpawnCano();
    }

    private void SpawnCano()
    {
        _tempoAtualSpawn -= Time.deltaTime;

        if (_tempoAtualSpawn <= 0)
        {
            float minY = posicaoChao.transform.position.y + 2f;
            float maxY = posicaoTeto.transform.position.y - 2f;

            float yAleatorio = UnityEngine.Random.Range(minY, maxY) + offsetAltura;

            GameObject novoCano = Instantiate(canoDuploPrefab);
            novoCano.transform.position = new Vector3(10, yAleatorio, 0);

            _tempoAtualSpawn = tempoSpawn;
        }
    }

    private bool VerificarForaDoMapa()
    {
        var verticalPos = PlayerFlappyBird.Instance.transform.position.y;

        return (verticalPos > posicaoTeto.transform.position.y ||
                verticalPos < posicaoChao.transform.position.y);
    }

    public void AdicionarPonto()
    {
        if (isGameOver) return;

        pontos++;
        textoPontos.text = pontos.ToString();
    }
}