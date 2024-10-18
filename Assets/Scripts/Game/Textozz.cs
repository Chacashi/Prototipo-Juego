using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textozz : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void SetHealth(int health)
    {
        healthText.text = health.ToString();
    }
}