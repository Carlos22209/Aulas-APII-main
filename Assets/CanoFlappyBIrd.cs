using UnityEngine;

public class CanoFlappyBird : MonoBehaviour
{
    [SerializeField] private float velocidade = 3.5f; // velocidade de movimento

    void Update()
    {
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        // destrói depois que sair da tela
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerFlappyBird player = other.gameObject.GetComponent<PlayerFlappyBird>();

        if (player != null)
            player.GameOver();
    }
}
