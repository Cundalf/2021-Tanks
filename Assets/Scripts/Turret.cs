using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform tankTurret;
    public GameObject prefabBullet;
    public Transform bulletOrigin;
    
    [SerializeField]
    private float bulletPower = 1.0f;
    [SerializeField]
    private float velocity = 1.0f;
    [SerializeField]
    private float fireCooldown = 0.1f;


    private float t;
    private bool f;
    private bool canFire = true;
    private GameObject bullet;

    void CancelarCoolDown()
    {
        canFire = true;
    }

    void Start()
    {
        bullet = GameObject.Instantiate(prefabBullet, bulletOrigin.position, bulletOrigin.rotation);
        bullet.SetActive(false);
    }

    void Update()
    {
        t = Input.GetAxis("Turret");
        f = Input.GetButtonDown("Fire1");

        //if (f && !bala.active)
        if (f && canFire)
        {
            canFire = false;

            bullet.SetActive(true);
            bullet.transform.position = bulletOrigin.position;
            bullet.transform.rotation = bulletOrigin.rotation;

            Rigidbody rbTank = GetComponent<Rigidbody>();
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.velocity = bulletOrigin.forward * bulletPower + rbTank.velocity;

            Invoke("CancelarCoolDown", fireCooldown);
        }
    }

    private void FixedUpdate()
    {
        tankTurret.Rotate(transform.up, t * velocity * Time.fixedDeltaTime);
    }
}
