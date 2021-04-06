using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattlefieldManager : MonoBehaviour
{
    public GameObject allyMelee;
    public GameObject allyRange;

    public GameObject enemyMelee;
    public GameObject enemyRange;

    public List<GameObject> Allies;

    public List<GameObject> Enemies;

    public GameObject treasureChest;

    [SerializeField]
    private int numAllies;

    [SerializeField]
    private int numAlliesRange;

    [SerializeField]
    private int numCurrentEnemies;

    InteractPrompt interactPrompt;

    // Start is called before the first frame update
    void Start()
    {

        interactPrompt = GameObject.Find("PlayerObject").GetComponentInChildren<InteractPrompt>();

        //Get the player pref for if their island is named
        //If nothing then set it to empty string
        if (PlayerPrefs.GetInt("allies") == 0)
        {
            PlayerPrefs.SetInt("allies", 0);
            PlayerPrefs.Save();
            numAllies = PlayerPrefs.GetInt("allies");
        }
        else
        {
            numAllies = PlayerPrefs.GetInt("allies");

        }

        //Get the player pref for if their island is named
        //If nothing then set it to empty string
        if (PlayerPrefs.GetInt("alliesRange") == 0)
        {
            PlayerPrefs.SetInt("alliesRange", 0);
            PlayerPrefs.Save();
            numAlliesRange = PlayerPrefs.GetInt("alliesRange");
        }
        else
        {
            numAlliesRange = PlayerPrefs.GetInt("alliesRange");
        }

        //Calc number of enemies to spawn
        numCurrentEnemies = (numAllies+numAlliesRange) * 2 + 10;

        SpawnAllies();

        SpawnEnemies(numCurrentEnemies);

        SpawnChests();
        
        }

    public void SpawnAllies()
    {
        //Ally Spawn area
        float minX = -110f; float maxX = -86f;
        float minZ = 333f; float maxZ = 356f;
        float y = 7f;


        //Spawn melee allies
        for (int i = 0; i < numAllies; i++)
        {
            //get random position
            float xPos = UnityEngine.Random.Range(minX, maxX);
            float zPos = UnityEngine.Random.Range(minZ, maxZ);

            //assign that position
            Vector3 randomPos3d = new Vector3(xPos, y, zPos);

            //add ally to list of allies (currently not done)
            Allies.Add(Instantiate(allyMelee, randomPos3d, UnityEngine.Random.rotation).transform.GetChild(0).gameObject);
        }

        //spawn range ally
        for (int i = 0; i < numAlliesRange; i++)
        {
            //get random position
            float xPos = UnityEngine.Random.Range(minX, maxX);
            float zPos = UnityEngine.Random.Range(minZ, maxZ);

            //assign that position
            Vector3 randomPos3d = new Vector3(xPos, y, zPos);

            //add ally to list of allies (currently not done)
            Allies.Add(Instantiate(allyRange, randomPos3d, UnityEngine.Random.rotation).transform.GetChild(0).gameObject);
        }
    }

    public void SpawnEnemies(int numEnemies)
    {
        //Split the number of enemies to be roughly even in each area

        //area 1
        SpawnEnemyArea(-1196, -374, 3, 619, 260, numEnemies/5);

        //area 2
        SpawnEnemyArea(-269, -357, -420, 99, 260, numEnemies/5);

        //area 3
        SpawnEnemyArea(183, 441, -1306, -467, 260, numEnemies/5);
        
        //area 4
        SpawnEnemyArea(-1122, 183, -1420, -1034, 260, numEnemies/5);

        //area 5
        SpawnEnemyArea(-1639, -1223, -551, 338, 260, numEnemies/5);
    }

    public void SpawnEnemyArea(int minX, int maxX, int minZ, int maxZ, int y, int numEnemies)
    {

        for (int i = 0; i < numEnemies; i++)
        {
            //get random position
            float xPos = UnityEngine.Random.Range(minX, maxX);
            float zPos = UnityEngine.Random.Range(minZ, maxZ);

            //assign that position
            Vector3 randomPos3d = new Vector3(xPos, y, zPos);

            float enemyType = UnityEngine.Random.Range(0, 2);

            if (enemyType == 0)
            {
                //add ally to list of allies (currently not done)
                Enemies.Add(Instantiate(enemyMelee, randomPos3d, UnityEngine.Random.rotation).transform.GetChild(0).gameObject);
            }
            else if (enemyType == 1)
            {
                //add ally to list of allies (currently not done)
                Enemies.Add(Instantiate(enemyRange, randomPos3d, UnityEngine.Random.rotation).transform.GetChild(0).gameObject);
            }
        }
    }

    public void SpawnChests()
    {
        //area 1
        SpawnChestArea(-1196, -374, 3, 619, 260);

        //area 2
        SpawnChestArea(-269, -357, -420, 99, 260);

        //area 3
        SpawnChestArea(183, 441, -1306, -467, 260);

        //area 4
        SpawnChestArea(-1122, 183, -1420, -1034, 260);

        //area 5
        SpawnChestArea(-1639, -1223, -551, 338, 260);
    }

    public void SpawnChestArea(int minX, int maxX, int minZ, int maxZ, int y) 
    {
        for (int i = 0; i < 3; i++)
        {
            //get random position
            float xPos = UnityEngine.Random.Range(minX, maxX);
            float zPos = UnityEngine.Random.Range(minZ, maxZ);

            //assign that position
            Vector3 randomPos3d = new Vector3(xPos, y, zPos);

            //add ally to list of allies (currently not done)
            GameObject chest = Instantiate(treasureChest, randomPos3d, UnityEngine.Random.rotation);
            interactPrompt.interactables.Add(chest);
            interactPrompt.interactablesPosition.Add(chest);
        }
    }

    public void RemoveAllyMelee(GameObject ally)
    {
        Allies.Remove(ally.transform.GetChild(0).gameObject);
        numAllies -= 1;
        Destroy(ally);
    }

    public void RemoveAllyRange(GameObject ally)
    {
        Allies.Remove(ally.transform.GetChild(0).gameObject);
        numAlliesRange -= 1;
        Destroy(ally);
    }

    public void RemoveEnemyMelee(GameObject enemy)
    {
        Enemies.Remove(enemy.transform.GetChild(0).gameObject);
        numCurrentEnemies -= 1;
        Destroy(enemy);
    }

    public void RemoveEnemyRange(GameObject enemy)
    {
        Enemies.Remove(enemy.transform.GetChild(0).gameObject);
        numCurrentEnemies -= 1;
        Destroy(enemy);
    }

    public void EndScene()
    {
        //update number of allies (melee and range)
        PlayerPrefs.SetInt("alliesRange", numAlliesRange);
        PlayerPrefs.SetInt("allies", numAllies);
        PlayerPrefs.Save();

        SceneManager.LoadScene("OpenExplore");
    }

}
