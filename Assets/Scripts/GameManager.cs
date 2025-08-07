using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;

    public void StartGame()
    {
        isGameStarted = true;
        Debug.Log("Game Started");
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
}
