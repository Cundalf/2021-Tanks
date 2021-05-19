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
    private float fireCooldown = 0.1f;
    [SerializeField]
    private float turrentRotationSpeed = 1.0f;

    private bool f;
    private bool canFire = true;
    private GameObject bullet;
    private Camera playerCamera;
    private Quaternion rotationObj;

    void CancelarCoolDown()
    {
        canFire = true;
    }

    void Start()
    {
        bullet = GameObject.Instantiate(prefabBullet, bulletOrigin.position, bulletOrigin.rotation);
        bullet.SetActive(false);
        playerCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        Ray rayPicking = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int mask = (1 << LayerMask.NameToLayer("Ground"));
        bool hasCollision = Physics.Raycast(rayPicking, out hit, 100.0f, mask);

        if(hasCollision)
        {
            Vector3 dir = (hit.point - tankTurret.position);
            dir.y = 0.0f;
            dir.Normalize();
            Debug.Log($"Direccion {dir}");
            rotationObj = Quaternion.LookRotation(dir, Vector3.up);
        }

        f = Input.GetButtonDown("Fire1");

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
        tankTurret.rotation = Quaternion.Slerp(tankTurret.rotation, rotationObj, turrentRotationSpeed * Time.fixedDeltaTime);
    }
}
