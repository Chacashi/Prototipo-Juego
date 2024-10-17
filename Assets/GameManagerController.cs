using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private int currentLife;
    [SerializeField] private Slider _compSlider;
    [SerializeField] EnemigoController _compEnemyController;


    private void Awake()
    {
        _compSlider = GetComponent<Slider>();
    }
    public void ChangueLifeMax(float maxLife)
    {
        _compSlider.maxValue = maxLife;
        
    }

    public void ChangueCurrentLife(float currentLife)
    {
        _compSlider.value = currentLife;
    }

    public void SetLifeBar(float currentLife)
    {
        ChangueCurrentLife(currentLife);
        ChangueLifeMax(currentLife);
    }

    public int GetDamageEnemy()
    {
        
        return _compEnemyController.GetDamage();

    }
}
