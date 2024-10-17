using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D RB2D;
    private float xdirection;
    private float ydirection;
    [SerializeField] private float Speed;
    [SerializeField] private float YMax;
    [SerializeField] private float YMin;
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    [SerializeField] private GameManagerController lifeBar;
    private float current;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        life = maxLife;
        lifeBar.SetLifeBar(life);
    }
    public void DecrementLife(int damage)
    {
        life -= damage;
        lifeBar.ChangueCurrentLife(life);
        
    }

    private void Update()
    {
        current=math.clamp(transform.position.y, YMin, YMax);
        transform.position = new Vector2(transform.position.x, current);
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
