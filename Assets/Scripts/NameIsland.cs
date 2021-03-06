using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameIsland : MonoBehaviour
{
    public GameObject startButton;
    public GameObject[] nameIslandObjects;
    
    private string islandName = "";

    // Start is called before the first frame update
    void Start()
    {
        //Get the player pref for if their island is named
        //If nothing then set it to empty string
        if (PlayerPrefs.GetString("islandName") == null)
        {
            PlayerPrefs.SetString("islandName", "");
            PlayerPrefs.Save();
            islandName = PlayerPrefs.GetString("islandName");
        }
        else
        {
            islandName = PlayerPrefs.GetString("islandName");
        }

        //if the person has an island already
        if (islandName != "")
        {
            //change start game to continue game
            startButton.GetComponentInChildren<Text>().text = "Continue Game";
        }
        else
        {
            startButton.GetComponentInChildren<Text>().text = "Start Game";
        }

        //Disable the name island objects to start
        for (int i = 0; i < nameIslandObjects.Length; i++)
        {
            nameIslandObjects[i].SetActive(false);
        }

    }

    public void startGame()
    {
        //if no island prompt them to make one
        if (islandName == "")
        {
            //disable start button and enable the naming island objects
            startButton.SetActive(false);
            for (int i = 0; i < nameIslandObjects.Length; i++)
            {
                nameIslandObjects[i].SetActive(true);
            }
        }
        else
        {
            //let them continue
            SceneManager.LoadScene("Island_1_Home");
        }
    }

    public void createIsland()
    {
        //Check the island name input to see if they named their island
        //nameIslandObjects[0] will be the input field, 1 = text, 2 = button
        if (nameIslandObjects[0].GetComponentInChildren<Text>().text == "")
        {
            nameIslandObjects[1].GetComponent<Text>().text = "Enter your New Island's Name.\nYou must name the island!";
        }

        else if (nameIslandObjects[0].GetComponentInChildren<Text>().text != "")
        {
            //save the new island name
            PlayerPrefs.SetString("islandName", nameIslandObjects[0].GetComponentInChildren<Text>().text);
            PlayerPrefs.Save();

            //open the next scene
            SceneManager.LoadScene("Island_1_Home");
        }
    }

}
