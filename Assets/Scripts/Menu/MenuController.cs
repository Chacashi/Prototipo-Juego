using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
    void Start()
    {
        menu.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Pausa()
    {
        botonPausa.SetActive(false);
        menu.SetActive(true);
    }
    public void Reanudar()
    {
        botonPausa.SetActive(true);
        menu.SetActive(false);
    }
}
