using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourShopController : MonoBehaviour
{
    //holds the alert box objects
    public GameObject alertBox;

    //holds the armour icon objects
    public GameObject[] armour;

    //doubloons text box
    public Text doubloonsTextBox;

    // Start is called before the first frame update
    void Start()
    {
            alertBox.SetActive(false);
    }

    public void purchaseArmour(int armourNum)
    {
        int doubloons = 1000;
        int cost;

        switch (armourNum)
        {
            case 14:
                cost = 10000;
                break;
            case 13:
                cost = 8000;
                break;
            case 12:
                cost = 6000;
                break;
            case 11:
                cost = 5000;
                break;
            case 10:
                cost = 4000;
                break;
            case 9:
                cost = 3000;
                break;
            case 8:
                cost = 2000;
                break;
            case 7:
                cost = 1000;
                break;
            case 6:
                cost = 900;
                break;
            case 5:
                cost = 750;
                break;
            case 4:
                cost = 600;
                break;
            case 3:
                cost = 500;
                break;
            case 2:
                cost = 350;
                break;
            case 1:
                cost = 200;
                break;
            case 0:
                cost = 100;
                break;
            default:
                cost = -1;
                break;
        }

        alertBox.SetActive(false);

        if (cost < 0)
        {
            //UnityEngine.Debug.Log("armourNum not valid");
        }
        else if (doubloons < cost)
        {
            alertBox.SetActive(true);
        }
        else
        {
            alertBox.SetActive(false);
            //decrease gold by how much armour cost
            //add armour to their collection
        }
    }
}
