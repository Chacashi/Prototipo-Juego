using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  
    [SerializeField] private Transform firePoint;      
    [SerializeField] private float bulletSpeed = 5f;  
    [SerializeField] private float fireRate = 1f;     

    private float nextFireTime; 

    private void Update()
    {
        if (Time.time >= nextFireTime) 
        {
            Shoot(); 
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * bulletSpeed; 

        Destroy(bullet, 5f); 
    }
}