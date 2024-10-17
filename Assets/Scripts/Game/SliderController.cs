using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    public void MostrarVida(float life)
    {
        slider.value= life ;
    }
    private void OnEnable()
    {
        PlayerController.eventLife += MostrarVida;
    }
    private void OnDisable()
    {
        PlayerController.eventLife -= MostrarVida;

    }
}
