using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArmourData
{
    public List<Armour> playerArmour = new List<Armour>();

    public ArmourData(armourStorageList playerArmourList)
    {
        playerArmour = playerArmourList.playerArmour;
    }
}
