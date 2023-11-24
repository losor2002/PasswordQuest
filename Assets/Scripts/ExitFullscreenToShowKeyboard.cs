using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitFullscreenToShowKeyboard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Necessario per far vedere la tastiera sui dispositivi con touchscreen
#if UNITY_WEBGL
        Screen.fullScreen = false;
#endif
    }
}
