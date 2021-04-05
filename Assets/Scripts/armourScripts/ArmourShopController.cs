using System.Collections;
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

    //List for the armour the player has
    private armourStorageList armourList = new armourStorageList();

    //How much doubloons someone has
    public int numberOfDoubloons;

    // Start is called before the first frame update
    void Start()
    {
        alertBox.SetActive(false);

        //get the data of what armour the person has
        ArmourData data = SaveSystem.loadArmour();
        if (data != null)
        {
            armourList.playerArmour = data.playerArmour;
        }
    }

    public void purchaseArmour(int armourNum)
    {
        //get how much gold they have
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

        //variable to represent cost of armour
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
            Debug.Log("armourNum not valid");
        }
        else if (numberOfDoubloons < cost)
        {
            StartCoroutine(InsufficientFundAlert());
        }
        else
        {
            //remove alert box saying not enough gold
            alertBox.SetActive(false);

            //decrease gold by how much armour cost
            numberOfDoubloons -= cost;
            PlayerPrefs.SetInt("doubloons", numberOfDoubloons);
            PlayerPrefs.Save();

            //add armour to their collection
            Armour armour = new Armour(armourNum, 100);
            armourList.playerArmour.Add(armour);
            SaveSystem.saveArmour(armourList);

            //Update text box for new amount of doubloons
            doubloonsTextBox.text = "Doubloons: "+numberOfDoubloons;
        }
    }

    IEnumerator InsufficientFundAlert()
    {
        alertBox.SetActive(true);

        yield return new WaitForSeconds(5f);

        alertBox.SetActive(false);
    }
}
