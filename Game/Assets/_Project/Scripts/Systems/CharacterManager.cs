using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private string characterPath = "Characters/";
    public string characterName;
    public CharacterBase characterPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterBase character = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        CharacterData data = DataSerializer.LoadJson<CharacterData>(characterPath + characterName);
        character.stats = data.stats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
