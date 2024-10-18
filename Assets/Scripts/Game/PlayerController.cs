using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RB2D;
    private float xdirection;
    private float ydirection;
    [SerializeField] private float Speed;
    [SerializeField] private float YMax;
    [SerializeField] private float YMin;
    [SerializeField] private float Xmin;
    [SerializeField] private float Xmax;
    [SerializeField] private float life;
    [SerializeField] private int maxLife;
    [SerializeField] private GameManagerController lifeBar;
    [SerializeField] private Textozz healthDisplay;
    private float current;
    private float currentX;
    public static Action<float> eventLife;

    private Animator animator;

    private float dashSpeed = 10f;
    private float dashDuration = 0.2f;
    private float dashCooldown = 1f;
    private bool isDashing = false;
    private bool canDash = true;
    private float dashTime;

    [SerializeField] private float attackRange = 1f; 
    private bool isAttacking = false;
    [SerializeField] private int damage; 

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        life = maxLife;
        healthDisplay.SetHealth((int)life);
    }
    public void DecrementLife()
    {
        life -= damage;
        healthDisplay.SetHealth((int)life);
        if (life <= 0)
        {
            SceneManager.LoadScene("Menu");
        }      
    }
    private void Update()
    {
        current = Mathf.Clamp(transform.position.y, YMin, YMax);
        currentX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector2(currentX, current);

        bool isMoving = xdirection != 0 || ydirection != 0;
        animator.SetBool("walk", isMoving);

        Vector3 characterScale = transform.localScale;

        if (xdirection < 0)
        {
            characterScale.x = -Mathf.Abs(characterScale.x);
        }
        else if (xdirection > 0)
        {
            characterScale.x = Mathf.Abs(characterScale.x);
        }
        transform.localScale = characterScale;

        if (life <= 0)
        {
            SceneManager.LoadScene("Menu"); 
        }
    }
    public void YDirection(InputAction.CallbackContext context)
    {
        ydirection = context.ReadValue<float>();
    }
    public void XDirection(InputAction.CallbackContext context)
    {
        xdirection = context.ReadValue<float>();
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash && (xdirection != 0 || ydirection != 0))
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        animator.SetBool("dash", true);
        float originalSpeed = Speed;

        Speed = dashSpeed;
        Vector2 dashDirection = new Vector2(xdirection, ydirection).normalized;
        RB2D.velocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        Speed = originalSpeed;
        isDashing = false;
        animator.SetBool("dash", false);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    private void FixedUpdate()
    {
        if (!isDashing)
        {
            RB2D.velocity = new Vector2(xdirection * Speed, ydirection * Speed);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }

    private void Attack()
    {      
        animator.SetBool("attack", true);
        isAttacking = true;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies) 
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemigoController>().DecrementLife(damage); 
            }
            else if (enemy.CompareTag("jefe"))
            {
                SceneManager.LoadScene("Victory");
            }
        }
        StartCoroutine(ResetAttackState());
    }
    private IEnumerator ResetAttackState()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("attack",false);
        isAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy" || collision.gameObject.tag == "bala")
        {
            DecrementLife();
        }
        else if (collision.gameObject.tag == "bala")
        {
            DecrementLife();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag=="curar")
        {
            Heal(1);
            Destroy(collision.gameObject);
        }
    }
    public void Heal(int amount)
    {
        life += amount;  
        if (life > maxLife) 
        {
            life = maxLife;
        }
        healthDisplay.SetHealth((int)life);
    }
}
