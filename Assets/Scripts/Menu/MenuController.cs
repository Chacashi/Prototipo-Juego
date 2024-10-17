using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    private float ydirection;
    private int index = 0;
    public void Ydirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ydirection = context.ReadValue<float>();
            if (ydirection > 0)
            {
                if (index < buttons.Length - 1)
                {
                    ++index;
                    Debug.Log(index);
                }

            }
            else if (ydirection < 0)
            {
                if (index > buttons.Length-1)
                {
                    --index;
                    Debug.Log(index);
                }
            }
        } 
    }
    public void Interactue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OptenerComponente();
        }
    }
    private void OptenerComponente()
    {
        if (buttons[index].GetComponent<ButtonClose>() != null)
        {
            buttons[index].GetComponent<ButtonClose>().OnClik();
        }
        else if (buttons[index].GetComponent<ButtonUi>() != null)
        {
            buttons[index].GetComponent<ButtonUi>().OnClik();
        }else if(buttons[index].GetComponent<ButtonLoadScene>() != null)
        {
            buttons[index].GetComponent<ButtonLoadScene>().OnClik();
        }

    }
}
