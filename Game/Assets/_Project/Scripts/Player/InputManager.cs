using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerBase player;

    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable(); 
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            Vector2 movement_vector = inputActions.Player.Move.ReadValue<Vector2>();
            movement_vector = movement_vector.normalized * player.speed * 1.5f;
            
            player.GetComponent<Rigidbody2D>().linearVelocity = movement_vector;
        }
    }
}
