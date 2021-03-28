using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DebugScript_GainDoubloons : MonoBehaviour
{
    public void gainDoubloons()
    {
        int numberOfDoubloons = PlayerPrefs.GetInt("doubloons");
        PlayerPrefs.SetInt("doubloons", numberOfDoubloons+1000);
        PlayerPrefs.Save();
    }
}
