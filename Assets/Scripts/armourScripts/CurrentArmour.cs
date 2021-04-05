using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentArmour : MonoBehaviour
{
    public GameObject[] armourIcons;

    public GameObject notificationBox;

    private int[] numberArmourAvailable = new int[15];

    //List for the armour the player has
    private armourStorageList armourList = new armourStorageList();

    //The current armour they are using
    private Armour currentArmour;

    //The index in the armour list for the current armour
    private int currentArmourIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        //get the data of what armour the person has
        ArmourData data = SaveSystem.loadArmour();
        if (data != null)
        {
            armourList.playerArmour = data.playerArmour;
        }

        //disable icons as default
        for (int i = 0; i < armourIcons.Length; i++)
        {
            armourIcons[i].SetActive(false);
        }

        //enable icons
        for (int i = 0; i < armourList.playerArmour.Count; i++)
        {
            int armourNum = armourList.playerArmour[i].level;
            armourIcons[armourNum].SetActive(true);
            numberArmourAvailable[armourNum] = numberArmourAvailable[armourNum]+1;

            Debug.Log("The number of level "+ armourNum + " armour is "+ numberArmourAvailable[armourNum]);
            Debug.Log("text in text box for the level above, before acounting for the above armour, is : "+armourIcons[armourNum].GetComponentInChildren<Text>().text);
            armourIcons[armourNum].GetComponentInChildren<Text>().text = "Take Armour (Number Owned: " + numberArmourAvailable[armourNum]+")";
        }
    }

    public void takeArmour(int level)
    {
        //go through the list of saved armours
        for (int i = 0; i < armourList.playerArmour.Count; i++)
        {
            //if the armour matches the one chosen
            if (armourList.playerArmour[i].level == level)
            {
                //set it as current armour
                currentArmour = armourList.playerArmour[i];
                currentArmourIndex = i;
                Debug.Log("level "+ currentArmour.level);
                Debug.Log("index "+currentArmourIndex);

                //notify user that armour was taken
                notificationBox.GetComponentInChildren<Text>().text = "Your current armour is level " + (currentArmour.level + 1);
                break;
                
            }
        }
    }

}
