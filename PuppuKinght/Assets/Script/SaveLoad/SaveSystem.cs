using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer (PlayerControl player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Boss
    public static void SaveBoss(BossManager boss)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/boss.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        BossData data = new BossData(boss);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static BossData LoadBoss()
    {
        string path = Application.persistentDataPath + "/boss.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            BossData data = formatter.Deserialize(stream) as BossData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Chest
    public static void SaveChest(ChestManager chest)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/chest.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ChestData data = new ChestData(chest);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ChestData LoadChest()
    {
        string path = Application.persistentDataPath + "/chest.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ChestData data = formatter.Deserialize(stream) as ChestData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Collection
    public static void SaveCollection(MenuCollectionManager collection)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/collection.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        MenuCollectionData data = new MenuCollectionData(collection);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MenuCollectionData LoadCollection()
    {
        string path = Application.persistentDataPath + "/collection.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MenuCollectionData data = formatter.Deserialize(stream) as MenuCollectionData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
