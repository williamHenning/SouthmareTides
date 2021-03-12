using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class InteractPrompt : MonoBehaviour
{
    public List<GameObject> interactablesPosition; //objects the player can interact with (actual position)
    public List<GameObject> interactables; //objects the player can interact with
    public GameObject interactPrompt; //the interact ui prompt

    public float minGold = 50f; //minimum gold the chest can give
    public float maxGold = 200f; //maximum gold the chest can give

    private string interact = ""; //string to determine what a user ccan interact with
    private int currentInteractable = -1; //determine which interactable in the list they are interacting with (index)

    private Boolean isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        interactPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //pause
        if (Time.timeScale==0)
        {
            isPaused = true;
            interactPrompt.SetActive(false);
            interact = "";
        }

        //unpause
        else if (Time.timeScale == 1)
        {
            isPaused = false;
        }

        if (isPaused) {
            //don't check for interactables
        }

        else {
                    for (int i = 0; i < interactables.Count; i++)
                    {
                        if (Vector3.Distance(interactablesPosition[i].transform.position, this.transform.position) < 5)
                        {
                            if (interactables[i].transform.tag == "Treasure")
                            {
                                interact = "treasure";
                                interactPrompt.GetComponentInChildren<Text>().text = "[E] Loot Treasure";
                                interactPrompt.SetActive(true);
                                currentInteractable = i;
                                break;
                            }
                            else if (interactables[i].transform.tag == "ReturnHome")
                            {
                                interact = "ship";
                                interactPrompt.GetComponentInChildren<Text>().text = "[E] Leave";
                                interactPrompt.SetActive(true);
                                break;
                            }
                        }
                        //By default make it so that there is nothing to interact with
                        interact = "";
                        interactPrompt.SetActive(false);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //Check if the person can interact with a treasure
                        if (interact == "treasure")
                        {
                            //generate the number of gold they earned
                            float goldFound = UnityEngine.Random.Range(minGold,maxGold);
                            int numberOfDoubloons;
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
                            numberOfDoubloons += (int)goldFound;
                            PlayerPrefs.SetInt("doubloons", numberOfDoubloons);
                            Debug.Log("treasure looted");
                            removeInteractable();
                        }
                        //Check if the person can interact with their ship while on an island
                        else if (interact == "ship")
                        {
                            Debug.Log("return to ship");
                            SceneManager.LoadScene("OpenExplore");
                        }
                        interactPrompt.SetActive(false);
                        interact = "";
                    }
                }
    }

    public void removeInteractable()
    {
        Destroy(interactables[currentInteractable]);
        interactables.RemoveAt(currentInteractable);

        Destroy(interactablesPosition[currentInteractable]);
        interactablesPosition.RemoveAt(currentInteractable);   
    }
}
