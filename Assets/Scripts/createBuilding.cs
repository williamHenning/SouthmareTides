using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class createBuilding : MonoBehaviour
{
    public GameObject[] building; // 000 = storehouse, blacksmith, tradepost
    public GameObject[] createButtons;
    public GameObject[] dummyBuildings;

    public Text doubloons;

    private int numberOfDoubloons;
    private string buildingsOwned;

    // Start is called before the first frame update
    void Start()
    {
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

        //If nothing then set it to empty string
        if (PlayerPrefs.GetString("buildings") == "" || PlayerPrefs.GetString("buildings") == null)
        {
            PlayerPrefs.SetString("buildings", "000");
            PlayerPrefs.Save();
            buildingsOwned = PlayerPrefs.GetString("buildings");
        }
        else
        {
            buildingsOwned = PlayerPrefs.GetString("buildings");
        }
    }

    public void create(int buildingNo)
    {
        //default to a number the player won't have
        int gold = 1000000;
        //storehouse = 150 doubloons
        if (buildingNo == 0)
        {
            gold = 150;
        }
        else if (buildingNo == 1)
        {
            gold = 300;
        }
        else if (buildingNo == 2)
        {
            gold = 500;
        }

        //if they have enough money
        if (gold < numberOfDoubloons)
        {
            //build building
            building[buildingNo].SetActive(true);
            
            //disable the build builing button
            createButtons[buildingNo].SetActive(false);

            //disable dummy buildings
            dummyBuildings[buildingNo].SetActive(false);

            //Make them pay doubloons for it
            numberOfDoubloons -= gold;
            PlayerPrefs.SetInt("doubloons", numberOfDoubloons);
            PlayerPrefs.Save();

            doubloons.text = "Doubloons: " + numberOfDoubloons;
            string newBuildingsOwned = "";
            //add the building to the list of one's they built
            if (buildingNo == 0)
            {
                newBuildingsOwned += "1" + buildingsOwned[1] + buildingsOwned[2];
            }
            else if (buildingNo == 1)
            {
                newBuildingsOwned += buildingsOwned[0] + "1" + buildingsOwned[2];
            }
            else if (buildingNo == 2)
            {
                newBuildingsOwned += buildingsOwned[0] + buildingsOwned[1] + "1";
            }
            else
            {
                Debug.Log("Something bad happened, bad building no");
            }

            PlayerPrefs.SetString("buildings", newBuildingsOwned);
            PlayerPrefs.Save();

        }
        //If they don't have enough money
        else
        {
            //Let them know (WIP)
        }
    }
}
