using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonsUIMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //gameobject to reference the button
    public GameObject button;

    //start by disabling the button
    void Start()
    {
        button.SetActive(false);
    }

    //when your mouse goes over the button show it
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.SetActive(true);
    }

    //when your mouse is no longer over the button disable it
    public void OnPointerExit(PointerEventData eventData)
    {
        button.SetActive(false);
    }
}
