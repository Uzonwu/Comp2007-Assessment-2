using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    private float moveSpeed = 5f; 
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float angle = 0f;
    private float radius = 5f;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = GetTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            targetPosition = GetTargetPosition();
        }
    }

    private Vector3 GetTargetPosition()
    {
        float x = originalPosition.x + Mathf.Cos(angle) * radius;
        float y = originalPosition.y + Mathf.Sin(angle) * radius;
        angle += 0.01f; 

        return new Vector3(x, y, originalPosition.z);
    }
}
