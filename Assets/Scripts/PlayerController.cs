using Unity.Mathematics;
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
    private float current;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
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
}
