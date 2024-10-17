using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour
{
    private Button mybutton;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        mybutton.onClick.AddListener(OnClik);
    }
    public void OnClik()
    {
        Debug.Log("Se cerro el juego");
        Application.Quit();
    }
}
    
