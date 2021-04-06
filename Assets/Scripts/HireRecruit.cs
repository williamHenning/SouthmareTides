using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireRecruit : MonoBehaviour
{
    //holds the alert box objects
    public GameObject alertBox;

    //doubloons text box
    public Text doubloonsTextBox;

    //allies melee text box
    public Text alliesMeleeTextBox;

    //allies range text box
    public Text alliesRangeTextBox;

    //How much doubloons someone has
    public int numberOfDoubloons;

    //how many melee allies they have
    public int numAlliesMelee;

    //how many range allies they have
    public int numAlliesRange;

    //how much a melee crewmate costs
    public int cost;

    //how much a range crewmate costs
    public int costRange;

    // Start is called before the first frame update
    void Start()
    {
        alertBox.SetActive(false);

        //get how much gold they have
        if (PlayerPrefs.GetInt("allies") == 0)
        {
            PlayerPrefs.SetInt("allies", 0);
            PlayerPrefs.Save();
            numAlliesMelee = (PlayerPrefs.GetInt("allies"));
        }
        else
        {
            numAlliesMelee = PlayerPrefs.GetInt("allies");
        }

        // Update text box for new number of allies
        alliesMeleeTextBox.text = "You have " + numAlliesMelee + " melee crewmates.";

        // Update text box for new number of allies
        alliesRangeTextBox.text = "You have " + numAlliesRange + " ranged crewmates.";

    }

    public void purchaseMeleeAlly()
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

        alertBox.SetActive(false);

        if (numberOfDoubloons < cost)
        {
            StartCoroutine(InsufficientFundAlert());
        }
        else
        {
            //remove alert box saying not enough gold
            alertBox.SetActive(false);

            //decrease gold by how much crewmate cost
            numberOfDoubloons -= cost;
            PlayerPrefs.SetInt("doubloons", numberOfDoubloons);
            PlayerPrefs.Save();

            //decrease gold by how much armour cost
            numAlliesMelee += 1;
            PlayerPrefs.SetInt("allies", numAlliesMelee);
            PlayerPrefs.Save();

            //Update text box for new amount of doubloons
            doubloonsTextBox.text = "Doubloons: " + numberOfDoubloons;

            //Update text box for new number of allies
            alliesMeleeTextBox.text = "You have " + numAlliesMelee + " melee crewmates.";
        }
    }

    public void purchaseRangeAlly()
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

        alertBox.SetActive(false);

        if (numberOfDoubloons < cost)
        {
            StartCoroutine(InsufficientFundAlert());
        }
        else
        {
            //remove alert box saying not enough gold
            alertBox.SetActive(false);

            //decrease gold by how much crewmate cost
            numberOfDoubloons -= cost;
            PlayerPrefs.SetInt("doubloons", numberOfDoubloons);
            PlayerPrefs.Save();

            //decrease gold by how much armour cost
            numAlliesRange += 1;
            PlayerPrefs.SetInt("alliesRange", numAlliesRange);
            PlayerPrefs.Save();

            //Update text box for new amount of doubloons
            doubloonsTextBox.text = "Doubloons: " + numberOfDoubloons;

            //Update text box for new number of allies
            alliesRangeTextBox.text = "You have " + numAlliesRange + " ranged crewmates.";
        }
    }


    IEnumerator InsufficientFundAlert()
    {
        alertBox.SetActive(true);

        yield return new WaitForSeconds(5f);

        alertBox.SetActive(false);
    }
}
