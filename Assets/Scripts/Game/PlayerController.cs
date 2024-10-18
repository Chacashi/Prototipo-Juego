using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;
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

    private float current;
    private float currentX;
    public static System.Action<float> eventLife;

    private Animator animator;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    private bool isDashing = false;
    private bool canDash = true;
    private float dashTime;

    [SerializeField] private float attackRange = 1f; 
    private bool isAttacking = false;
    [SerializeField] private int damage; 

    private void ActiveEventLife()
    {
        eventLife.Invoke(life);
    }

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ActiveEventLife();
    }

    public void DecrementLife(int damage)
    {
        life -= damage;
        ActiveEventLife();
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
        animator.SetTrigger("attack");
        isAttacking = true;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies) //FOREACH DEIDAD
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemigoController>().DecrementLife(damage); 
            }
        }

        StartCoroutine(ResetAttackState());
    }

    private IEnumerator ResetAttackState()
    {
        yield return new WaitForSeconds(0.5f); 
        isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isAttacking)
        {
            DecrementLife(lifeBar.GetDamageEnemy());
            Destroy(collision.gameObject);
        }
    }
}
