using UnityEngine;

public class PulpitManager : MonoBehaviour
{
    [SerializeField] private GameObject pulpitPrefab;

    private GameObject currentPulpit;

    private void Start()
    {
        if (pulpitPrefab == null)
        {
            Debug.LogError("Pulpit Prefab is not assigned!");
            return;
        }

        if (GameConfig.Instance == null)
        {
            Debug.LogError("GameConfig is not available!");
            return;
        }

        // Find the starting Pulpit already placed in the scene
        currentPulpit = GameObject.Find("Pulpit");

        if (currentPulpit == null)
        {
            Debug.LogError("Starting Pulpit not found!");
            return;
        }

        // Give the starting Pulpit its lifetime + timer
        SchedulePulpitDestruction(currentPulpit);

        // Spawn the next Pulpit
        Invoke(nameof(SpawnNextPulpit), GameConfig.Instance.SpawnTime);
    }

    private void SpawnNextPulpit()
    {
        if (currentPulpit == null)
        {
            return;
        }

        Vector3 currentPosition = currentPulpit.transform.position;

        Vector2Int[] directions =
        {
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0),  // Left
            new Vector2Int(0, 1),   // Forward
            new Vector2Int(0, -1)   // Backward
        };

        Vector2Int direction =
            directions[Random.Range(0, directions.Length)];

        Vector3 nextPosition = currentPosition + new Vector3(
            direction.x * 9f,
            0f,
            direction.y * 9f
        );

        GameObject nextPulpit = Instantiate(
            pulpitPrefab,
            nextPosition,
            Quaternion.identity
        );

        Debug.Log("New Pulpit spawned at: " + nextPosition);

        currentPulpit = nextPulpit;

        // Give the new Pulpit its lifetime + timer
        SchedulePulpitDestruction(nextPulpit);

        // Schedule the next Pulpit
        Invoke(
            nameof(SpawnNextPulpit),
            GameConfig.Instance.SpawnTime
        );
    }

    private void SchedulePulpitDestruction(GameObject pulpit)
    {
        float destroyTime = Random.Range(
            GameConfig.Instance.MinDestroyTime,
            GameConfig.Instance.MaxDestroyTime
        );

        Debug.Log(
            "Pulpit will be destroyed in " +
            destroyTime +
            " seconds."
        );

        // Start the timer on this Pulpit
        PulpitTimer timer = pulpit.GetComponentInChildren<PulpitTimer>();

        if (timer != null)
        {
            timer.StartTimer(destroyTime);
        }
        else
        {
            Debug.LogWarning(
                "PulpitTimer not found on " + pulpit.name
            );
        }

        // Destroy the Pulpit after the SAME amount of time
        Destroy(pulpit, destroyTime);
    }
    public GameObject GetCurrentPulpit()
    {
        return currentPulpit;
    }
}
