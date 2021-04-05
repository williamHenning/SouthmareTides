using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static void saveArmour(armourStorageList armourList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/armour.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        ArmourData armourData = new ArmourData(armourList);

        formatter.Serialize(stream, armourData);
        stream.Close();
    }
    
    public static ArmourData loadArmour()
    {
        string path = Application.persistentDataPath + "/armour.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ArmourData armourList = formatter.Deserialize(stream) as ArmourData;
            stream.Close();

            return armourList;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();
            Debug.LogError("No save file found at "+path);
            return null;
        }
    }

}
