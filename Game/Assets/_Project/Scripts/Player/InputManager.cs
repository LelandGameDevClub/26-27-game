using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : ScriptableObject
{
    public PlayerBase player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            float x_input = Input.GetAxis("Horizontal");
            float y_input = Input.GetAxis("Vertical");

            Vector2 movement_vector = new Vector2(x_input, y_input);
            movement_vector = movement_vector.normalized * player.speed;
            
            player.GetComponent<Rigidbody>().linearVelocity = movement_vector;
        }
    }
}
