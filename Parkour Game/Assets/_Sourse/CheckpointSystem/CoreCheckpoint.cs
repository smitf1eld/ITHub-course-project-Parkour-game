using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoreCheckpoint : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private int maxCheckpoints = 3;
    public TextMeshProUGUI CountCheckPoints;
    public static int CounterCP = 5;

    private Vector3[] checkpoints;
    private int currentCheckpointIndex = -1;

    private CameraFollow cameraFollow;
    private void Start()
    {
        CounterCP = maxCheckpoints;
    }
    private void Update()
    {
        CountCheckPoints.text = CounterCP.ToString();
    }

    private void Awake()
    {
        checkpoints = new Vector3[maxCheckpoints];
        cameraFollow = FindObjectOfType<CameraFollow>();
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

    public void TeleportToLastCheckpoint()
    {
        if (currentCheckpointIndex >= 0)
        {
            TeleportPlayer(checkpoints[currentCheckpointIndex]);
        }
    }

    private void TeleportPlayer(Vector3 position)
    {
        playerTransform.position = position;
        if (cameraFollow != null)
        {
            cameraFollow.TeleportToPosition(position);
        }

        Debug.Log("Игрок телепортирован на позицию " + position);
    }
}