using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private int currentLife;
    [SerializeField] EnemigoController _compEnemyController;

    public int GetDamageEnemy()
    {
        
        return _compEnemyController.GetDamage();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

}
