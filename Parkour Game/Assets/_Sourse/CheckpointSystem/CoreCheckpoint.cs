using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCheckpoint : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private int maxCheckpoints = 3;

    private Vector3[] checkpoints;
    private int currentCheckpointIndex = -1;

    private CameraFollowCP cameraFollow;

    private void Awake()
    {
        checkpoints = new Vector3[maxCheckpoints];
        cameraFollow = FindObjectOfType<CameraFollowCP>();
    }

    public void SetCheckpoint()
    {
        if (currentCheckpointIndex < maxCheckpoints - 1)
        {
            currentCheckpointIndex++;
            checkpoints[currentCheckpointIndex] = playerTransform.position;
            Debug.Log("Установлен чекпоинт: " + currentCheckpointIndex);
        }
    }

    public void ReturnToLastCheckpoint()
    {
        if (currentCheckpointIndex >= 0)
        {
            RespawnPlayer(checkpoints[currentCheckpointIndex]);
        }
    }

    public void RespawnPlayer(Vector3 position)
    {
        DestroyImmediate(playerTransform.gameObject);
        GameObject newPlayer = Instantiate(playerPrefab, position, Quaternion.identity);

        playerTransform = newPlayer.transform;
        if (cameraFollow != null)
        {
            cameraFollow.AssignTarget(playerTransform);
        }

        Debug.Log("Игрок возрожден на позиции " + position);
    }
}