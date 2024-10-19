using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Reference to the button
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the button is visible when the game starts
        myButton.gameObject.SetActive(true);
    }

    // Function to restart the level
    public void RestartLevel()
    {
        // Optionally reload the current scene (to restart the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
