using UnityEngine;
using System.Collections.Generic;

public class CheckpointSystem : MonoBehaviour
{
    public static CheckpointSystem Instance { get; private set; }
    
    [SerializeField] private PlayerRespawn playerRespawn;
    [SerializeField] private DeathZone deathZone;
    [SerializeField] private FadeEffect fadeEffect;
    
    private List<Checkpoint> allCheckpoints = new List<Checkpoint>();
    private Checkpoint currentCheckpoint;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        InitializeSystem();
    }
    
    private void InitializeSystem()
    {
        allCheckpoints.AddRange(FindObjectsOfType<Checkpoint>());
        
        if (allCheckpoints.Count == 0)
        {
            Debug.LogError("No checkpoints found in the scene!");
            return;
        }
        
        SetCheckpoint(allCheckpoints[0]);
        
        if (deathZone != null)
        {
            deathZone.OnPlayerFell += HandlePlayerDeath;
        }
    }
    
    public void SetCheckpoint(Checkpoint newCheckpoint)
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.Deactivate();
        }
        
        currentCheckpoint = newCheckpoint;
        currentCheckpoint.Activate();
        
        Debug.Log($"Checkpoint set to: {currentCheckpoint.name}");
    }
    
    private void HandlePlayerDeath()
    {
        if (currentCheckpoint == null) return;
        
        fadeEffect.StartFade(() => 
        {
            playerRespawn.Respawn(currentCheckpoint.GetSpawnPosition());
            fadeEffect.StartUnfade();
        });
    }
    
    public Vector3 GetCurrentSpawnPosition()
    {
        return currentCheckpoint != null ? currentCheckpoint.GetSpawnPosition() : Vector3.zero;
    }
    
    private void OnDestroy()
    {
        if (deathZone != null)
        {
            deathZone.OnPlayerFell -= HandlePlayerDeath;
        }
    }
}