using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject bulletPref;
    public float bulletVel = 20f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPref, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVel;
        }
    }
}
