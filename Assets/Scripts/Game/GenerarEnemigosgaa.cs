using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerarEnemigosgaa : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public float velocidad;
    public float final;

    private void Update()
    {
        velocidad += Time.deltaTime;
        if(velocidad>=final)
        {
            Vector2 newPosition = new Vector2(this.transform.position.x, Random.Range(-3.5f, -0.62f));
            GameObject newEnemy = Instantiate(prefab, newPosition, transform.rotation);
            newEnemy.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            velocidad = 0;
        }
    }
}
