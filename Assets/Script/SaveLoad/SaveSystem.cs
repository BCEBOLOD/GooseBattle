using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(PlayerContoll player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerSave.Player";
        FileStream FS = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        bf.Serialize(FS, data);
        FS.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerSave.Player";
        if (File.Exists(path))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream FS = new FileStream(path, FileMode.Open);
            PlayerData data = BF.Deserialize(FS) as PlayerData;
            FS.Close();
            return data;
        }
        else
        {
            Debug.LogError("Empty save");
            return null;
        }
    }

}
