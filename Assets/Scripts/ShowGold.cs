using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGold : MonoBehaviour
{
    public Text doubloonsText;

    private int numberOfDoubloons;


    // Start is called before the first frame update
    void Start()
    {
        //Get the player pref for if their island is named
        //If nothing then set it to empty string
        if (PlayerPrefs.GetInt("doubloons") == 0)
        {
            PlayerPrefs.SetInt("doubloons", 0);
            PlayerPrefs.Save();
            numberOfDoubloons = (PlayerPrefs.GetInt("doubloons"));
        }
        else
        {
            numberOfDoubloons = PlayerPrefs.GetInt("doubloons");
        }


        doubloonsText.text = "Doubloons: " + numberOfDoubloons;   
    }
}
