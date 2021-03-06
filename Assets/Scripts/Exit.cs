using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void exitGame()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }
        Application.Quit();
    }
}
