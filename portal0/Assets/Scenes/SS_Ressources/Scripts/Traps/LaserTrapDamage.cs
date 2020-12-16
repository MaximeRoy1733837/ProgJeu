using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrapDamage : MonoBehaviour
{

    private LineRenderer lineRenderer;
    public GameObject laserImpact;

    private float laserImpactCooldown = 0.05f;
    private float laserImpactCooldownValue = 0f;

    private float playerDamageCooldown = 0.05f;
    private float playerDamageCooldownValue = 0.05f;
    public float trapDamage = 10f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        laserImpactCooldownValue -= Time.deltaTime;
        playerDamageCooldownValue -= Time.deltaTime;
        lineRenderer.SetPosition(0, transform.root.position - transform.position);
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.root.position, transform.root.forward, out raycastHit)) {

            if (raycastHit.collider) {

                if (laserImpactCooldownValue <= 0) {
                    SpawnLaserImpactPS(raycastHit.point, raycastHit.normal); 
                    laserImpactCooldownValue = laserImpactCooldown;

                }

                lineRenderer.SetPosition(1, raycastHit.point - transform.position);
                if (raycastHit.collider.tag == "Player") {

                    DealDamage();
                }
            }

        } else {

            lineRenderer.SetPosition(1, transform.root.forward * 10000);

        }
    }

    private void SpawnLaserImpactPS(Vector3 aHitPosition, Vector3 aHitRotation) {

        Quaternion quaternion = Quaternion.Euler(aHitRotation.x, aHitRotation.y + 180, aHitRotation.z);
        GameObject laserImpactAtPosition = (GameObject)Instantiate(laserImpact, aHitPosition, quaternion);
        Destroy(laserImpactAtPosition, laserImpactCooldown);
    }

    private void DealDamage() {

        if (playerDamageCooldownValue <= 0) {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Damage(trapDamage);
            playerDamageCooldownValue = playerDamageCooldown;
        }
    }
}
