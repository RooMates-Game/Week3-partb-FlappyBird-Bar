using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] public float animationSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0);
    }
}
