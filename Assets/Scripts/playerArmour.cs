using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerArmour : MonoBehaviour
{
    private static playerArmour playerArmourInstance;

    public Armour armour;
    public int armourIndex;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (playerArmourInstance == null)
        {
            playerArmourInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void changeArmour(Armour armr, int index)
    {
        playerArmourInstance.armour = armr;
        playerArmourInstance.armourIndex = index;
    }

    public Armour GetArmour()
    {
        return playerArmourInstance.armour;
    }

    public int GetArmourIndex()
    {
        return playerArmourInstance.armourIndex;
    }

}
