using System.IO;
using UnityEngine;

public static class DataSerializer
{
    public static T LoadJson<T>(string relativePath)
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, relativePath);

        if (!File.Exists(fullPath))
        {
            Debug.LogError($"Path does not exist: {fullPath}");
            return default;
        }

        string json = File.ReadAllText(fullPath);
        return JsonUtility.FromJson<T>(json);
    }
}