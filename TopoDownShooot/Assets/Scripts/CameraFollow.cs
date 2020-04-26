using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        transform.position = playerTransform.position;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            var clampX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            var clampY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampX, clampY), speed);   
        }
    }
}
