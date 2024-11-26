using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] string triggeringTag_GameOver;
    [SerializeField] string triggeringTag_Pipes;
    public GameObject playButton;
    public GameObject gameOver;
    Scoring scoring;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        this.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        this.enabled = false;
        this.transform.position = Vector3.zero;
    }

    public void GameOver()
    {
        // Display game over UI
        gameOver.SetActive(true);
        playButton.SetActive(true);
        scoring = Object.FindFirstObjectByType<Scoring>();
        if (scoring != null)
        {
            scoring.ResetScore();
        }
        // Destroy all pipes
        DestroyAllPipes();

        Pause();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggeringTag_GameOver == other.tag)
        {
            GameOver();
        }
    }

    private void DestroyAllPipes()
    {
        // Find all objects with the "Pipe" tag
        GameObject[] pipes = GameObject.FindGameObjectsWithTag(triggeringTag_Pipes);

        // Destroy each pipe object
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }
}
