using UnityEngine;

public static class DataSerializer
{
    // Loads through Resources rather than reading the file directly, because
    // Application.dataPath only exists in the editor -- a built game has no Assets folder.
    // resourcePath is relative to any Resources folder, with no extension: "Characters/character_1"
    public static T LoadJson<T>(string resourcePath)
    {
        TextAsset asset = Resources.Load<TextAsset>(resourcePath);

        if (asset == null)
        {
            Debug.LogError($"No JSON asset found at Resources path: {resourcePath}");
            return default;
        }

        return JsonUtility.FromJson<T>(asset.text);
    }
}
