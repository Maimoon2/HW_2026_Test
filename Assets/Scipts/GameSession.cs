using UnityEngine;

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
