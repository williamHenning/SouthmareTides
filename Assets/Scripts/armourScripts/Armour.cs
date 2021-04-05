using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armour
{
   public int level;
   public int durability;

    public Armour(int lvl, int dur)
    {
        level = lvl;
        durability = dur;
    }
}
