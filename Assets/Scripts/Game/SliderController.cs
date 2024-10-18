using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    public Slider slider;
    private float life;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = life;
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
