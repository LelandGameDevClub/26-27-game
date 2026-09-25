using UnityEngine;
using System.Collections.Generic;

public class CharacterBase : MonoBehaviour
{
    private Dictionary<string, int> stats = new()
    {
        {"Athletics", 0},
        {"Will", 0},
        {"Intellect", 0},
        {"Charisma", 0}
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
