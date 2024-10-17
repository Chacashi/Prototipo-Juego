using Unity.Mathematics;
using UnityEngine;
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
    public static Action<float> eventLife;
    private void ActiveEventLife()
    {
        eventLife.Invoke(life);
    }
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
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
        current=math.clamp(transform.position.y, YMin, YMax);
        currentX = math.clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector2(currentX, current);
    }
    public void YDirection(InputAction.CallbackContext context)
    {
        ydirection = context.ReadValue<float>();
    }
    public void XDirection(InputAction.CallbackContext context)
    {
        xdirection = context.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(xdirection* Speed, ydirection * Speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag =="Enemy")
        {
            DecrementLife(lifeBar.GetDamageEnemy());
            Destroy(collision.gameObject);
        }
    }

}
