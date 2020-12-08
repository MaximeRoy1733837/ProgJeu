using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public Transform laserPos;

    public  Transform LaserBeamPrefab;

    public AudioSource audio;
    public AudioClip laserSound;

    public float shootForce = 90.0f;

    private void OnFireGun()
    {
        if (LaserBeamPrefab != null)
        {
            CreateAndFireBullet(laserPos);
            audio.PlayOneShot(laserSound, 0.3f);
        }
    }

    private void CreateAndFireBullet(Transform startPos)
    {
        var laser = (Transform)Instantiate(LaserBeamPrefab, startPos.position, startPos.rotation);

        laser.GetComponent<Rigidbody>().velocity = startPos.forward * shootForce;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (GameObject.FindObjectOfType<Shoot>() !=null && GameObject.FindObjectOfType<Shoot>().CanShoot)
            {
                OnFireGun();
            }
        }
    }
}
