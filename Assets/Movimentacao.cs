using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    KeyCode teclaCima = KeyCode.W;
    KeyCode teclaBaixo = KeyCode.S;
    KeyCode teclaEsquerda = KeyCode.A;
    KeyCode teclaDireita = KeyCode.D;

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 1f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 deslocamentoFrame = Vector2.zero;

        
        if (Input.GetKey(teclaEsquerda))
        {
            deslocamentoFrame += Vector2.left;
        }

        if (Input.GetKey(teclaDireita))
        {
            deslocamentoFrame += Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0,jumpForce));
        }

        if (deslocamentoFrame == Vector2.zero) return;
        _rb.velocity = deslocamentoFrame*speed;
        //_rb.velocity = new Vector2(deslocamentoFrame.x*speed,_rb.velocity.y);
    }
}
