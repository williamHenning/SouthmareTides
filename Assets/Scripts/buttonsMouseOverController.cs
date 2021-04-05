using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsMouseOverController : MonoBehaviour
{
    public GameObject button;


    // Start is called before the first frame update
    void Start()
    {
        //disable the button to start
        button.SetActive(false);
    }

    void OnMouseOver()
    {
        button.SetActive(true);
    }

    void OnMouseExit()
    {
        button.SetActive(false);
    }
}
