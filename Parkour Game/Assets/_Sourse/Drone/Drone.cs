using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform[] points;
    private int pointIndex = 0;

    private void Update()
    {
        if (points == null || points.Length == 0)
        {
            return;
        }

        MoveToPoint();
    }
    private void MoveToPoint()
    {
        Transform targetPoint = points[pointIndex];

        Vector3 direction = (targetPoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetPoint.position);
        if (distance < 0.2f)
        {
            pointIndex++;

            if (pointIndex >= points.Length)
            {
                pointIndex = 0;
            }
        }
    }
}