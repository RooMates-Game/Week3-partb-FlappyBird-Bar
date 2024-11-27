using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer; // Renderer to manipulate background texture
    [SerializeField] public float animationSpeed = 1f; // Speed of background scrolling

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // Assign the mesh renderer
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); // Scroll the texture
    }
}
