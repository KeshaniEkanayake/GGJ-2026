using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Scene Loading")]
    [Tooltip("The name of the scene to load when 'Play' is pressed.")]
    public string gameSceneName = "Game"; // change this to your gameplay scene name

    [Header("Panels")]
    public GameObject optionsPanel;

    // Called by Play button
    public void PlayGame()
    {
        // Make sure the scene is added in Build Settings
        if (string.IsNullOrEmpty("SampleScene"))
        {
            Debug.LogError("Game scene name not set on MainMenuUI.");
            return;
        }
        SceneManager.LoadScene("SampleScene");
    }

    // // Called by Options button
    // public void OpenOptions()
    // {
    //     if (optionsPanel != null)
    //         optionsPanel.SetActive(true);
    // }

    // // Called by Back button in Options
    // public void CloseOptions()
    // {
    //     if (optionsPanel != null)
    //         optionsPanel.SetActive(false);
    // }

    // Called by Quit button
    public void QuitGame()
    {
        // In the editor, this does nothing; in a build, it quits the app
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
