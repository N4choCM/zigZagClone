using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    public int score;
    public Text scoreText; // UI Text to display the score
    public Text maxScoreText; // UI Text to display the max score

    private void Awake()
    {
        maxScoreText.text = "Max Score: " + GetMaxScore().ToString(); // Initialize max score text
    }

    public void StartGame()
    {
        isGameStarted = true;
        Debug.Log("Game Started");
        FindFirstObjectByType<GamePath>().InitMapBuild(); // Start building the map
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame(); // Start the game when 'Return' is pressed
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0); // Reload the current scene to restart the game
    }

    // Method to increase the score in one point
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString(); // Update the score text in the UI

        if(score > GetMaxScore())
        {
            PlayerPrefs.SetInt("MaxScore", score);
            maxScoreText.text = "Max Score: " + score.ToString(); // Update the max score text in the UI
        }
    }
    
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore");
    }
}
