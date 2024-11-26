using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    public TextMeshProUGUI scoreText;
    private int score;
    private void OnTriggerEnter2D(Collider2D other){
        if(triggeringTag == other.tag)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void Start() {
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

}
