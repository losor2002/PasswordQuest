using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMobileKeyboard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TMP_InputField inputField;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform)
        {
            TouchScreenKeyboard.Open(inputField.text);
        }
    }
}
