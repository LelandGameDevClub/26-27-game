using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private string characterPath = "Characters/";
    public string characterName;
    public CharacterBase characterPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadCharacter(characterPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCharacter(CharacterBase prefab)
    {
        CharacterBase character = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        CharacterData data = DataSerializer.LoadJson<CharacterData>(characterPath + characterName);
        character.stats = data.stats;
        character.speed = data.speed;
    }
}
