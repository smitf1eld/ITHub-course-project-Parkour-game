using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    [SerializeField] private float reachDistance = 10f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerCamera;
    private int currentTargetIndex = 0;

    void Update()
    {
        if (currentTargetIndex >= targets.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        //                                                                     тут                            дальность от игрока  
        Vector3 frontPosition = playerCamera.position + playerCamera.forward * 3f + Vector3.down * 0.5f;
        transform.position = frontPosition;
        Vector3 toTarget = targets[currentTargetIndex].position - player.position;
        toTarget.y = 0f;



        if (toTarget.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(toTarget.normalized);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        }
        if (toTarget.magnitude <= reachDistance)
        {
            currentTargetIndex++;
        }
    }
}