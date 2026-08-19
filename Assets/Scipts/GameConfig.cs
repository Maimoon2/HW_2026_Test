using UnityEngine;

[System.Serializable]
public class PlayerData { public float speed; }

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

[System.Serializable]
public class DoofusDiary
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

public class GameConfig : MonoBehaviour
{
    public static GameConfig Instance { get; private set; }
    [SerializeField] private TextAsset doofusDiaryJson;

    public float Speed { get; private set; }
    public float MinDestroyTime { get; private set; }
    public float MaxDestroyTime { get; private set; }
    public float SpawnTime { get; private set; }

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (doofusDiaryJson == null)
        {
            Debug.LogError("doofusDiaryJson TextAsset not assigned!");
            return;
        }

        var diary = JsonUtility.FromJson<DoofusDiary>(doofusDiaryJson.text);
        Speed = diary.player_data.speed;
        MinDestroyTime = diary.pulpit_data.min_pulpit_destroy_time;
        MaxDestroyTime = diary.pulpit_data.max_pulpit_destroy_time;
        SpawnTime = diary.pulpit_data.pulpit_spawn_time;

        Debug.Log($"JSON Loaded Successfully! " +$"Speed: {Speed}, " +$"Min Destroy: {MinDestroyTime}, " +$"Max Destroy: {MaxDestroyTime}, " +$"Spawn Time: {SpawnTime}");
    }
}
