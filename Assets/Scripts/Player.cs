using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Renderer to display player sprites
    private Vector3 direction; // Direction vector for movement
    public Sprite[] sprites; // Array of sprites for animation
    private int spriteIndex; // Current index of the sprite being displayed
    [SerializeField] public float gravity = -9.8f; // Downward force applied to the player

    [SerializeField] public float strengh = 5f; // Upward force applied when the player moves up

    [SerializeField] InputAction moveUp = new InputAction(type: InputActionType.Button); // Input action for upward movement

    [SerializeField] private float animationSpeed = 0.15f; // Speed of sprite animation

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Assign the SpriteRenderer component

        if (moveUp.bindings.Count == 0) // Check if no input bindings are defined
        {
            moveUp.AddBinding("<Mouse>/leftButton"); // Bind left mouse click
            moveUp.AddBinding("<Keyboard>/space");  // Bind spacebar
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationSpeed, animationSpeed); // Start sprite animation loop
    }

    void OnEnable()
    {
        moveUp.Enable(); // Enable the input action for upward movement
    }

    void OnDisable()
    {
        moveUp.Disable(); // Disable the input action when the object is inactive
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp.IsPressed()) // Check if the move-up input is pressed
        {
            direction = Vector3.up * strengh; // Apply upward movement
        }

        direction.y += gravity * Time.deltaTime; // Apply gravity over time
        transform.position += direction * Time.deltaTime; // Update the player's position
    }

    private void AnimateSprite()
    {
        spriteIndex++; // Move to the next sprite in the array

        if (spriteIndex >= sprites.Length) // Loop back to the first sprite if at the end
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex]; // Set the current sprite
    }
}
