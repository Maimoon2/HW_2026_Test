using UnityEngine;
using TMPro;

public class PulpitTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float remainingTime;

    public void StartTimer(float duration)
    {
        remainingTime = duration;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime < 0f)
            remainingTime = 0f;

        timerText.text = remainingTime.ToString("0.00");
    }
}
