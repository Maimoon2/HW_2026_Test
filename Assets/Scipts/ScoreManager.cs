/*using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    //[SerializeField] private TMP_Text scoreText;
    [SerializeField]  private Text coinText;

    private int score = 0;

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
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private Text scoreText;
    private int score = 0;
    private GameObject currentPulpit;

    public int Score => score;

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
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private Text scoreText;
    private int score = 0;
    private HashSet<GameObject> visitedPulpits = new HashSet<GameObject>();
    public int Score => score;

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
        visitedPulpits.Clear();
        if (pulpit != null)
        {
            visitedPulpits.Add(pulpit);
        }
    }

    public void ReachedPulpit(GameObject newPulpit)
    {
        if (newPulpit == null)
            return;

        // Already scored for this Pulpit — don't score again
        if (visitedPulpits.Contains(newPulpit))
            return;

        visitedPulpits.Add(newPulpit);
        score++;
        UpdateScoreUI();
        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
