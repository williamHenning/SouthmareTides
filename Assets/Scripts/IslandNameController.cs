using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandNameController : MonoBehaviour
{
    public Text nameTextBox;
    private string islandName = "";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("islandName") == null)
        {
            PlayerPrefs.SetString("islandName", "your island");
            PlayerPrefs.Save();
            islandName = PlayerPrefs.GetString("islandName");
        }
        else
        {
            islandName = PlayerPrefs.GetString("islandName");
        }

        nameTextBox.text = "Welcome to " + islandName + " island";
    }
}
