using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] string triggeringTag_GameOver; // Tag to detect game-over collisions
    [SerializeField] string triggeringTag_Pipes; // Tag for identifying pipes in the game
    [SerializeField] public GameObject playButton; // UI play button
    [SerializeField] public GameObject gameOver; // UI game-over panel
    Scoring scoring; // Reference to the scoring system
    
    [SerializeField] private int frameRate = 60; // Target frame rate for the game

    private void Awake()
    {
        Application.targetFrameRate = frameRate; // Set the frame rate when the game starts
        Pause(); // Start the game in a paused state
    }

    public void Play()
    {
        playButton.SetActive(false); // Hide the play button
        gameOver.SetActive(false); // Hide the game-over UI

        Time.timeScale = 1f; // Resume the game
        this.enabled = true; // Enable the GameManager functionality
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        this.enabled = false; // Disable the GameManager functionality
        this.transform.position = Vector3.zero; // Reset the GameManager's position (optional use case)
    }

    public void GameOver()
    {
        // Display game-over UI elements
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        scoring = Object.FindFirstObjectByType<Scoring>(); // Find the Scoring component
        if (scoring != null)
        {
            scoring.ResetScore(); // Reset the player's score
        }

        DestroyAllPipes(); // Remove all pipe objects from the scene

        Pause(); // Pause the game
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggeringTag_GameOver == other.tag) // Check if the collider's tag matches the game-over tag
        {
            GameOver(); // Trigger game-over logic
        }
    }

    private void DestroyAllPipes()
    {
        // Find all game objects tagged as pipes
        GameObject[] pipes = GameObject.FindGameObjectsWithTag(triggeringTag_Pipes);

        // Iterate through the pipes and destroy each one
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }
}
