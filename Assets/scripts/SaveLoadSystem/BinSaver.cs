using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinSaver : ISaver
{
    private BinaryFormatter formatter = new BinaryFormatter();
    private string _path;

    public BinSaver(string SavePath)
    {
        _path = SavePath;
    }

    public void Save(object data)
    {
        var file = File.Create(Application.persistentDataPath + _path);
        formatter.Serialize(file, data);
        file.Close();
    }
}