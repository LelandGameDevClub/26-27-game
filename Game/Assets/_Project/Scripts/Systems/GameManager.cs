using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterManager characterManager;
    public InputManager inputManager;

    public PlayerBase player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterManager = Instantiate(characterManager);
        player = (PlayerBase)characterManager.LoadCharacter(player, "character_1");

        inputManager = Instantiate(inputManager);
        inputManager.player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
