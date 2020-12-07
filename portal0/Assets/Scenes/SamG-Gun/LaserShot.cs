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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnFireGun()
    {
        if (LaserBeamPrefab != null)
        {
            CreateAndFireBullet(laserPos);
            audio.PlayOneShot(laserSound, 1f);
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
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            OnFireGun();
        }
    }
}
