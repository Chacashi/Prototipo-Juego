using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletController : MonoBehaviour
{
    Rigidbody2D RB2D;
    public float speed;
    private void Awake()
    {
        RB2D=GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        RB2D.velocity=new Vector2(speed,RB2D.velocity.x);
    }
    
}

