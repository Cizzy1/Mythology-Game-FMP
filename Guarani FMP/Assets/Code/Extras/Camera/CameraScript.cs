using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2.5f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float SmoothSpeed = .25f; 
    public Transform Player;

    void LateUpdate()
    {
        Vector3 targetPosition = Player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothSpeed);
    }
}
