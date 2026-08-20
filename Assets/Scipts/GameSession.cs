/*using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;

    [SerializeField] private GameObject scoreUI;

    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        IsGameOver = false;

        // Activate Score UI when the game starts
        if (scoreUI != null)
        {
            scoreUI.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        Debug.Log("GAME OVER");
    }
}
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.Start);
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        if (CurrentState == GameState.GameOver)
            return;

        SetState(GameState.GameOver);
    }

    private void SetState(GameState newState)
    {
        CurrentState = newState;

        Debug.Log("Game State: " + CurrentState);
    }
}*/
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;

    public bool IsGameOver { get; private set; }
    public bool IsGameStarted { get; private set; }

    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private Text finalScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        IsGameOver = false;
        IsGameStarted = false;

        if (startUI != null)
            startUI.SetActive(true);

        if (scoreUI != null)
            scoreUI.SetActive(false);

        if (gameoverUI != null)
            gameoverUI.SetActive(false);
    }

    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;

        if (startUI != null)
            startUI.SetActive(false);

        if (scoreUI != null)
            scoreUI.SetActive(true);

        if (gameoverUI != null)
            gameoverUI.SetActive(false);

        PulpitManager pulpitManager =FindFirstObjectByType<PulpitManager>();

        if (pulpitManager != null)
        {
            pulpitManager.StartSpawning();
        }

        Debug.Log("GAME STARTED");
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        if (scoreUI != null)
            scoreUI.SetActive(false);

        if (gameoverUI != null)
            gameoverUI.SetActive(true);

        if (finalScoreText != null && ScoreManager.Instance != null)
        {
            finalScoreText.text = ScoreManager.Instance.Score.ToString();
            Debug.Log("FinalScore:");
        }

        PulpitManager pulpitManager =FindFirstObjectByType<PulpitManager>();

        if (pulpitManager != null)
        {
            pulpitManager.StopSpawning();
        }

        Debug.Log("GAME OVER");
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
