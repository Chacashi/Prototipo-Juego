using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
    private Button mybutton;
    [SerializeField] private string Scene;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        mybutton.onClick.AddListener(OnClik);
    }
    public void OnClik()
    {
        Debug.Log("Cambiaste a la Scena " + Scene);
        SceneManager.LoadScene(Scene);
    }
}
