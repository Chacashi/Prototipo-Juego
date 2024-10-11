using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonLoadScene : MonoBehaviour
{
    [SerializeField] private string Scena;
    Button mybutton;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        mybutton.onClick.AddListener(Onclick);
    }
    private void Onclick()
    {
        print("Machuco");
        SceneManager.LoadScene(Scena);
    }

}
