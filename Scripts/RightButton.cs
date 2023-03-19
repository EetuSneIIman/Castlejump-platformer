using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        Debug.Log("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        Debug.Log("Not Pressing");
    }
}
