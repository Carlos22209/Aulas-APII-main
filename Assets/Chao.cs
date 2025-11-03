using UnityEngine;

public class Chao : MonoBehaviour
{
    [SerializeField] private float velocidade = 4f;
    private Vector3 posicaoInicial;
    private float larguraChao;

    void Start()
    {
        posicaoInicial = transform.position;
        larguraChao = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // move o chao pra esquerda
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        // quando sai da tela, volta pra posição inicial
        if (transform.position.x <= posicaoInicial.x - larguraChao)
        {
            transform.position = posicaoInicial;
        }
    }
}
