using System;
using UnityEngine;

public class ProjetilITJ : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private int   projectileDamage = 10;
    
    [HideInInspector] public GameObject shotFrom;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        
        _rb2D.velocity = transform.up * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == shotFrom) return;

        var otherTank = other.GetComponent<PlayerITJ>();
        if(otherTank != null) otherTank.TakeDamage(projectileDamage);
        
        Destroy(gameObject);
    }
}
