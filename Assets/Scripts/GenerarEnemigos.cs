using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject go= Instantiate(prefab,transform.position,transform.rotation);
            Destroy(go,0.1f);
        }
    }
}
