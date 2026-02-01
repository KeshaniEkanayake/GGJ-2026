// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;

// public class GameOverManager : MonoBehaviour
// {
//     [Header("UI References")]
//     [SerializeField] private GameObject gameOverPanel;
//     [SerializeField] private TMP_Text titleText;
//     [SerializeField] private TMP_Text scoreText;

//     [Header("Options")]
//     [Tooltip("Pause gameplay time when showing Game Over")]
//     [SerializeField] private bool pauseOnGameOver = true;

//     private bool isGameOver = false;

//     // Singleton-like quick access (optional)
//     public static GameOverManager Instance { get; private set; }

//     private void Awake()
//     {
//         // Simple singleton pattern (optional)
//         if (Instance != null && Instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }
//         Instance = this;

//         // Ensure hidden on start
//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(false);
//     }

//     /// <summary>
//     /// Call this when the player dies. Pass the current score to show.
//     /// </summary>
//     public void ShowGameOver(int finalScore)
//     {
//         if (isGameOver) return; // prevent double calls
//         isGameOver = true;

//         if (pauseOnGameOver)
//             Time.timeScale = 0f; // pause the game

//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(true);

//         if (titleText != null)
//             titleText.text = "You Died";

//         if (scoreText != null)
//             scoreText.text = $"Score: {finalScore}";
//     }

//     public void RestartLevel()
//     {
//         // Unpause and reload the same scene
//         Time.timeScale = 1f;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

    // public void LoadMainMenu()
    // {
    //     // Unpause and load a scene by name (make sure it's in Build Settings)
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene("MainMenu"); // change to your menu scene name
    // }
// }

























/////////////////////////////////////////////////////////////////////////////
/// 
// // this contains the script needed to display the 'Player dead screen'

// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;

// public class GameOverManager : MonoBehaviour
// {
//     [Header("UI References")]
//     [SerializeField] private GameObject gameOverPanel;
//     [SerializeField] private TMP_Text titleText;
//     [SerializeField] private TMP_Text scoreText;

//     [Header("Options")]
//     [Tooltip("Pause gameplay time when showing Game Over")]
//     [SerializeField] private bool pauseOnGameOver = true;

//     private bool isGameOver = false;

//     // Singleton-like quick access (optional)
//     public static GameOverManager Instance { get; private set; }

//     private void Awake()
//     {
//         // Simple singleton pattern (optional)
//         if (Instance != null && Instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }
//         Instance = this;

//         // Ensure hidden on start
//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(false);
//     }

//     /// <summary>
//     /// Call this when the player dies. Pass the current score to show.
//     /// </summary>
//     public void ShowGameOver(int finalScore)
//     {
//         if (isGameOver) return; // prevent double calls
//         isGameOver = true;

//         if (pauseOnGameOver)
//             Time.timeScale = 0f; // pause the game

//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(true);

//         if (titleText != null)
//             titleText.text = "You Died";

//         if (scoreText != null)
//             scoreText.text = $"Score: {finalScore}";
//     }

//     public void RestartLevel()
//     {
//         // Unpause and reload the same scene
//         Time.timeScale = 1f;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void LoadMainMenu()
//     {
//         // Unpause and load a scene by name (make sure it's in Build Settings)
//         Time.timeScale = 1f;
//         SceneManager.LoadScene("MainMenu"); // change to your menu scene name
//     }
// }