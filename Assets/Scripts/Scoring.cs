using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] string triggeringTag; // Tag to identify objects for scoring
    [SerializeField] public TextMeshProUGUI scoreText; // UI element for displaying the score
    private int score; // Tracks the player's score

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggeringTag == other.tag) // Check if the collided object's tag matches
        {
            score++; // Increment the score
            scoreText.text = score.ToString(); // Update the displayed score
        }
    }

    private void Start()
    {
        ResetScore(); // Initialize the score when the game starts
    }

    public void ResetScore()
    {
        score = 0; // Reset the score to zero
        scoreText.text = score.ToString(); // Update the displayed score
    }
}
