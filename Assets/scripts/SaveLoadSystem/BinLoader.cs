using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinLoader : ILoader
{
    private BinaryFormatter formatter = new BinaryFormatter();
    private string _path;

    public BinLoader(string loadPath)
    {
        _path = loadPath;
    }

    public object Load()
    {
        if (File.Exists(Application.persistentDataPath + _path))
        {
            var file = File.Open(Application.persistentDataPath + _path, FileMode.Open);
            var data = formatter.Deserialize(file);
            file.Close();
            return data;
        }
        return null;
    }
}
