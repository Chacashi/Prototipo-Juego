using UnityEngine;
using UnityEngine.UI;

public class ButtonUi : MonoBehaviour
{
    private Button mybutton;
    [SerializeField] private GameObject Close;
    [SerializeField] private GameObject Open;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        mybutton.onClick.AddListener(OnClik);
    }
    public void OnClik()
    {
        Close.gameObject.SetActive(false);
        Open.gameObject.SetActive(false);
        Debug.Log("Se interactuo con el button ui");
    }
}
