using UnityEngine;
using System.IO; //namespace we want to use when working with files on Operating System
using System.Runtime.Serialization.Formatters.Binary; //allows access to BinaryFormatter

public static class SaveSystem //static class is just a class that can't be instantiated // don't want multiple
{
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "saves");
        //Debug.Log($"Path.Combine = {Path.Combine(Application.persistentDataPath, "saves")}");
        //FileStream allows us to read and write from a file, from System.IO class
        using (FileStream stream = new FileStream(path, FileMode.Create)) //seems like stream is a function which creates a file here within the path
        {
            PlayerData data = new PlayerData(player);

            formatter.Serialize(stream, data);
            Debug.Log("GAME SAVED!");
        }
        //stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "saves");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open)) //opening the "stream" from "path"
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData; //deserializing the stream
                return data;
            }
            //stream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
