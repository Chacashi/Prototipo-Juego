using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RB2D;
    private float Y;
    private float X;
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
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(X * Speed, Y * Speed);
    }
}
