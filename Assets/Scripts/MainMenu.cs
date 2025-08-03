using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This script handles the main menu functionality
    // It allows the player to start the game or exit the application
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    // This method is called when the player clicks the exit button
    // It logs a message and quits the application
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
