using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float linealVelocity = 1.5f;
    public float rotationVelocity = 1.0f;

    private Rigidbody _rb;
    private float h;
    private float v;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.angularVelocity = h * transform.up * rotationVelocity;
        _rb.velocity = v * transform.forward * linealVelocity;
    }
}
