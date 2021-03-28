using UnityEngine;
using UnityEngine.UI;

public class buildingAppearController : MonoBehaviour
{
    public GameObject[] buildings; // 000 = storehouse, blacksmith, tradepost

    public GameObject[] buildingButtons; //the enter building buttons

    public GameObject[] dummyBuildings; //the dummy objects to represent the unbuilt buildings

    public GameObject[] dummyBuildingsButtons; //the dummy objects buttons to build the buildings

    private string buildingsOwned = "";

    // Start is called before the first frame update
    void Start()
    {
        //Get the player pref for if their buildings they own
        //If nothing then set it to empty string
        if (PlayerPrefs.GetString("buildings") == ""|| PlayerPrefs.GetString("buildings") == null)
        {
            PlayerPrefs.SetString("buildings", "000");
            PlayerPrefs.Save();
            buildingsOwned = PlayerPrefs.GetString("buildings");
        }
        else
        {
            buildingsOwned = PlayerPrefs.GetString("buildings");
        }

        //if no storehouse
        if (buildingsOwned[0].Equals('0')) {
            //make it dissapear
            buildings[0].SetActive(false);
            //change button to off
            buildingButtons[0].SetActive(false);
        }
        //if there is a storehouse
        else if (buildingsOwned[0].Equals('1'))
        {
            buildings[0].SetActive(true);

            //disable the dummy objects for the storehouse
            dummyBuildings[0].SetActive(false);
            dummyBuildingsButtons[0].SetActive(false);
        }
        //something else
        else
        {
            Debug.Log("The value in playerpref 0: "+buildingsOwned[0]);
            Debug.Log("Something is wrong with storehouse");
        }

        //if no blacksmith
        if (buildingsOwned[1].Equals('0'))
        {
            buildings[1].SetActive(false);
            buildingButtons[1].SetActive(false);
        }
        //if there is a blacksmith
        else if (buildingsOwned[1].Equals('1'))
        {
            buildings[1].SetActive(true);

            dummyBuildings[1].SetActive(false);
            dummyBuildingsButtons[1].SetActive(false);
        }
        //something else
        else
        {
            Debug.Log("The value in playerpref 1: " + buildingsOwned[1]);
            Debug.Log("Something is wrong with blacksmith");
        }

        //if no trader
        if (buildingsOwned[2].Equals('0'))
        {
           buildings[2].SetActive(false);
           buildingButtons[2].SetActive(false);
        }
        //if there is a trader
        else if (buildingsOwned[2].Equals('1'))
        {
            buildings[2].SetActive(true);

            dummyBuildings[2].SetActive(false);
            dummyBuildingsButtons[2].SetActive(false);
        }
        //something else
        else
        {
            Debug.Log("The value in playerpref 2: " + buildingsOwned[2]);
            Debug.Log("Something is wrong with trader");
        }

    }
}
