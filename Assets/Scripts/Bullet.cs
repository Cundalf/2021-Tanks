using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip explosionSound;
    public ParticleSystem prefabExplosion;
    public float explotionRatio = 1.0f;
    private Collider[] cols;

    private void Start()
    {
        cols = new Collider[20];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        SFXManager sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        sfxManager.PlaySound(explosionSound, transform.position);

        GameObject.Instantiate(prefabExplosion, transform.position, Quaternion.identity);

        int cant = Physics.OverlapSphereNonAlloc(transform.position, explotionRatio, cols);
        for (int i = 0; i < cant; ++i)
        {
            var c = cols[i];
            SubBlock sb = c.GetComponent<SubBlock>();
            if (sb != null)
            {
                sb.damage();
            }
        }

        gameObject.SetActive(false);
    }
}
