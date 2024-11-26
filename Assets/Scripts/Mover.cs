using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] public float speed = 5f;
    // [SerializeField] public GameObject gameOver;

    private float leftEdge;

    [SerializeField] private float extraDistanceLeft = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - extraDistanceLeft;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //if the pipe exit the left side screen , then destory it. 
        if(transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
}
