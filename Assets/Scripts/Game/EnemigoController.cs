using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoController : MonoBehaviour
{
    Rigidbody2D r;
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;
    [SerializeField] private int damage;
    private int currentHealth;
    private void Awake()
    {
        r = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        r.velocity = new Vector2(-speed, r.velocity.y);
    }

    public int GetDamage()
    {
        return damage;
    }

    public void DecrementLife(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
