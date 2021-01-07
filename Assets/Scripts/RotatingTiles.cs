using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTiles : MonoBehaviour
{
    public Transform rotationCenter;
    public float rotationRadius = 2f;
    public float angularSpeed = 2f;

    private float posX, posY;
    private float angle = 0f;
    public float initialAngle = 0f;

    void Update()
    {    
        posX = rotationCenter.position.x + Mathf.Cos(initialAngle + angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(initialAngle + angle) * rotationRadius;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if(angle >= 360f)
        {
            angle = 0f;
        }
    }
}
