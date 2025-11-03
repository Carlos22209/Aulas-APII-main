using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
public class PlayerAnimacaoBC : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private Animator _animator;

    [SerializeField] private float velocidadeCorrida = 5f;
    [SerializeField] private float velocidadePulo = 10f;
    
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovimentoLateral();
        Pular();
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.velocity = new  Vector2(_rb2D.velocity.x, velocidadePulo);
        }
        
        _animator.SetFloat("VelocidadeY", _rb2D.velocity.y);
    }

    private void MovimentoLateral()
    {
        float mov = 0f;

        if (Input.GetKey(KeyCode.A)) mov -= 1f;
        if (Input.GetKey(KeyCode.D)) mov += 1f;

        if (mov != 0f)
        {
            _rb2D.velocity = new Vector2(mov * velocidadeCorrida, _rb2D.velocity.y);    
        }

        if(_rb2D.velocity.x > +0.05f) transform.localScale = new Vector3(+1f, 1f, 1f);
        if(_rb2D.velocity.x < -0.05f) transform.localScale = new Vector3(-1f, 1f, 1f);
        
        _animator.SetFloat("VelocidadeX", Mathf.Abs(_rb2D.velocity.x));
    }
}
