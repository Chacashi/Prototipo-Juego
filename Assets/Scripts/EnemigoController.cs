using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    Rigidbody2D r;
    public float speed;
    private void Awake()
    {
        r = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        r.velocity = new Vector2(-speed, r.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
