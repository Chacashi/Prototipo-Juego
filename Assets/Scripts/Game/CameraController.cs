using UnityEngine;
using System;
public class CameraController : MonoBehaviour
{
    [HeaderAttribute("Objetive Variable")]
    public GameObject Jugador;
    [HeaderAttribute("Pocisiones en X")]
    public float minPositionX;
    public float maxPositionX;
    public float currentPositionX;
    [HeaderAttribute("Pocisiones en Y")]
    public float minPositionY;
    public float maxPositionY;
    public float currentPositionY;

    public float timeToGetOBjetive;
    private Vector3 Velocity = new Vector3(0, 0, 0);

    private Vector3 realObjetive;
    private void Update()
    {
        currentPositionX = Math.Clamp(Jugador.transform.position.x, minPositionX, maxPositionX);
        currentPositionY = Math.Clamp(Jugador.transform.position.y, minPositionY, maxPositionY);
        realObjetive = new Vector3(currentPositionX, currentPositionY, -10);
        transform.position = Vector3.SmoothDamp(transform.position, realObjetive, ref Velocity, timeToGetOBjetive);
    }
}
