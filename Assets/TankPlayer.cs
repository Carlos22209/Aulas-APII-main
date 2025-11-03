using System;
using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 25f;
    
    // References
    private Rigidbody2D _rb2d;
    [SerializeField] private GameObject projectilePrefab;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var obj = Instantiate(projectilePrefab);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }
    }

    private void Move()
    {
        //// Movimentação frontal
        // Primeiro vou pegar a tecla WS clicada
        var cliqueFrontal = 0f;
        if(Input.GetKey(KeyCode.W)) cliqueFrontal+=1;
        if(Input.GetKey(KeyCode.S)) cliqueFrontal-=1;
        
        // Depois vou alterar a velocidade linear
        if(cliqueFrontal!=0f) _rb2d.velocity = speed * cliqueFrontal * transform.up;
        
        //// Movimentação de rotação
        // Primeiro vou pegar a tecla AD clicada
        var cliqueLateral = 0f;
        if (Input.GetKey(KeyCode.D)) cliqueLateral += (Input.GetKey(KeyCode.S)) ? +1 : -1;
        if (Input.GetKey(KeyCode.A)) cliqueLateral += (Input.GetKey(KeyCode.S)) ? -1 : +1;
        
        if(cliqueLateral!=0f) _rb2d.angularVelocity = rotationSpeed * cliqueLateral;
        // Depois vou alterar a velocidade angular

    }
}