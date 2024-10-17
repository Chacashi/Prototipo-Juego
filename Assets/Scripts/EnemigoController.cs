using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    Rigidbody2D r;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private void Awake()
    {
        r = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        r.velocity = new Vector2(-speed, r.velocity.y);
    }

    public int GetDamage()
    {
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
