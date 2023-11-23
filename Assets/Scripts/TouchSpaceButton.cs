using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSpaceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Interaction.TouchSpacePressed = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
