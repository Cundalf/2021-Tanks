using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float distance = 10.0f;
    public Transform target;
    public float velocity = 1.0f;
    private float physicalDistance = 10.0f;
    private Camera c;

    void Start()
    {
        c = GetComponent<Camera>();
        c.orthographic = true;
        c.orthographicSize = distance;
    }

    void FixedUpdate()
    {
        c.orthographicSize = distance;

        var target = this.target.position + this.target.up * physicalDistance;
        transform.position = Vector3.Lerp(transform.position, target, velocity * Time.deltaTime);
    }
}
