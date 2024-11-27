using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public float speed = 5f; // Speed of leftward movement
    private float leftEdge; // Leftmost boundary for object destruction
    [SerializeField] private float extraDistanceLeft = 1f; // Extra buffer before destruction

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - extraDistanceLeft; // Calculate destruction boundary
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Move the object leftward

        if (transform.position.x < leftEdge) // Destroy the object if it moves out of bounds
        {
            Destroy(gameObject);
        }
    }
}
