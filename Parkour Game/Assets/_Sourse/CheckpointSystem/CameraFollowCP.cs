using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCP : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    private void Update()
    {
        if (followTarget != null)
        {
            transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        }
    }

    public void AssignTarget(Transform newTarget)
    {
        followTarget = newTarget;
    }
}