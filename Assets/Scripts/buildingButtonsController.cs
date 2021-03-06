using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingButtonsController : MonoBehaviour
{
    public GameObject buildingButtons;


    // Start is called before the first frame update
    void Start()
    {
        //disable the button to start
        buildingButtons.SetActive(false);
    }

    void OnMouseOver()
    {
        buildingButtons.SetActive(true);
    }

    void OnMouseExit()
    {
        buildingButtons.SetActive(false);
    }
}
