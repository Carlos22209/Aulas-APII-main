using System;
using UnityEngine;

public class PlayerITJ : MonoBehaviour
{
    private float speed = 5f;
    private float rotationSpeed = 40f;

    public int HP = 100;
    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSPawnPoint;
    
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoverLinear();
        MoverRotacao();

        Atirar();
    }

    private void Atirar()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var obj = Instantiate(projectilePrefab).GetComponent<ProjetilITJ>();
        
        obj.transform.position = projectileSPawnPoint.position;
        obj.transform.rotation = projectileSPawnPoint.rotation;

        obj.shotFrom = gameObject;
    }

    private void MoverRotacao()
    {
        var mov = 0f;

        if (Input.GetKey(KeyCode.A)) mov += 1f;
        if (Input.GetKey(KeyCode.D)) mov -= 1f;

        if (mov == 0f) return;

        var rear = (Input.GetKey(KeyCode.S)? -1f : +1f);

        _rb2D.angularVelocity = mov * rotationSpeed * rear;
    }

    private void MoverLinear()
    {
        var mov = 0f;

        if (Input.GetKey(KeyCode.W)) mov += 1f;
        if (Input.GetKey(KeyCode.S)) mov -= 1f;

        if (mov == 0f) return;
        
        _rb2D.velocity = mov * speed * transform.up;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP<= 0) Destroy(gameObject);
    }
}
