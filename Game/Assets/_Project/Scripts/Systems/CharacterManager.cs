using UnityEngine;
using System.IO;

public class CharacterManager : MonoBehaviour
{
    public string characterPath;
    public CharacterBase character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterData data = DataSerializer.LoadJson<CharacterData>(characterPath);
        character.stats = data.stats;
    }
    private string LoadFile(string fileLocation)
    {
        byte[] buffer;
        using (FileStream fs = File.OpenRead(fileLocation))
        {
            buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
        }
        return System.Text.Encoding.UTF8.GetString(buffer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
