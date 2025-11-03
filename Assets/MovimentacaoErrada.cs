using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoErrada : MonoBehaviour
{
    KeyCode teclaCima = KeyCode.W;
    KeyCode teclaBaixo = KeyCode.S;
    KeyCode teclaEsquerda = KeyCode.A;
    KeyCode teclaDireita = KeyCode.D;

    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 deslocamentoFrame = Vector2.zero;

        if (Input.GetKey(teclaCima))
        {
            deslocamentoFrame += Vector2.up;
        }

        if (Input.GetKey(teclaBaixo))
        {
            deslocamentoFrame += Vector2.down;
        }

        if (Input.GetKey(teclaEsquerda))
        {
            deslocamentoFrame += Vector2.left;
        }

        if (Input.GetKey(teclaDireita))
        {
            deslocamentoFrame += Vector2.right;
        }

        transform.position += (Vector3)deslocamentoFrame.normalized * speed;
    }
}
