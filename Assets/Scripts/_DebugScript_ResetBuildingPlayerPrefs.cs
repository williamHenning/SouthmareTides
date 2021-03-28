using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DebugScript_ResetBuildingPlayerPrefs : MonoBehaviour
{
    public void ResetBuildings()
    {
     PlayerPrefs.SetString("buildings", "000");
     PlayerPrefs.Save();
        
    }
}
