using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 5f; 
    private Transform player;                 
    private Vector2 targetDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player != null)
        {
            targetDirection = (player.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemigoController player = collision.GetComponent<EnemigoController>();
            if (player != null)
            {
                player.DecrementLife((int)damage);
            }
            Destroy(gameObject);
        }
    }
}