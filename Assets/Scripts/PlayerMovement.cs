using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float linealVelocity = 1.5f;
    public float rotationVelocity = 1.0f;
    public AudioClip movementSound;
    public AudioClip idleSound;
    public Vector2 pitchMinMax = new Vector2(1.0f, 1.4f);

    private AudioSource audioSource;
    private Rigidbody _rb;
    private float h;
    private float v;
    private Vector2 velMinMax;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        velMinMax = new Vector2(0.0f, linealVelocity);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (audioSource != null)
        {
            if (_rb.velocity.sqrMagnitude > 0.1f)
            {
                if ((audioSource.clip != movementSound) || !audioSource.isPlaying)
                {
                    audioSource.clip = movementSound;
                    audioSource.Play();
                }

                float pitchCoef = Mathf.InverseLerp(velMinMax.x, velMinMax.y, _rb.velocity.magnitude);
                audioSource.pitch = Mathf.Lerp(pitchMinMax.x, pitchMinMax.y, pitchCoef);
            }
            else
            {
                if ((audioSource.clip != idleSound) || !audioSource.isPlaying)
                {
                    // Poner sonido de estar quieto
                    audioSource.clip = idleSound;
                    audioSource.Play();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.angularVelocity = h * transform.up * rotationVelocity;
        _rb.velocity = v * transform.forward * linealVelocity + Vector3.up * _rb.velocity.y;
    }
}
