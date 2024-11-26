using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    public Sprite[] sprites;
    private int spriteIndex;
    [SerializeField] public float gravity = -9.8f;

    [SerializeField] public float strengh = 5f;

    [SerializeField]InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField] private float animationSpeed = 0.15f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (moveUp.bindings.Count == 0)
        {
            moveUp.AddBinding("<Mouse>/leftButton"); // Left mouse click
            moveUp.AddBinding("<Keyboard>/space");  // Spacebar
        }
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), animationSpeed , animationSpeed);
    }

    void OnEnable()  {
        moveUp.Enable();
    }

    void OnDisable()  {
        moveUp.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp.IsPressed())
        {
            direction = Vector3.up * strengh;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
