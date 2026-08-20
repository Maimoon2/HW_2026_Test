using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TMP_Text scoreText;

    private int score = -1;

    private GameObject currentPulpit;

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
        UpdateScoreUI();
    }

    public void SetStartingPulpit(GameObject pulpit)
    {
        currentPulpit = pulpit;
    }

    public void ReachedPulpit(GameObject newPulpit)
    {
        if (newPulpit == null)
            return;

        // Don't score twice for the same Pulpit
        if (newPulpit == currentPulpit)
            return;

        currentPulpit = newPulpit;

        score++;

        UpdateScoreUI();

        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        //ScoreUI.SetActive(true);
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
