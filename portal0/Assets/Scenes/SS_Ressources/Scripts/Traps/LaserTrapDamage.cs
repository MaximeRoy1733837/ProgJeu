using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrapDamage : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private LaserController laserController;
    public GameObject laserImpact;

    private float laserImpactCooldown = 0.05f;
    private float laserImpactCooldownValue = 0f;

    private float playerDamageCooldown = 0.05f;
    private float playerDamageCooldownValue = 0.05f;
    public float trapDamage = 10f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserController = GetComponent<LaserController>();
    }

    void Update()
    {
        laserImpactCooldownValue -= Time.deltaTime;
        playerDamageCooldownValue -= Time.deltaTime;
        RenderLaser();
    }

    private void RenderLaser() {

        lineRenderer.SetPosition(0, transform.root.position - transform.position);
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.root.position, transform.root.forward, out raycastHit)) {

            if (raycastHit.collider) {

                if (laserImpactCooldownValue <= 0) {

                    SpawnLaserImpactPS(raycastHit.point, new Vector3(raycastHit.normal.x, raycastHit.normal.z, raycastHit.normal.y));
                    laserImpactCooldownValue = laserImpactCooldown;
                    print(raycastHit.normal);

                }

                lineRenderer.SetPosition(1, raycastHit.point - transform.position);
                if (raycastHit.collider.tag == "Player") {

                    DealDamage();
                }
            }

        } else {

            lineRenderer.SetPosition(1, transform.root.forward * 10000);

        }
        Vector3 lineRendererRotation = new Vector3(lineRenderer.transform.rotation.x - transform.root.rotation.x, lineRenderer.transform.rotation.y - transform.root.rotation.y, lineRenderer.transform.rotation.z - transform.root.rotation.z);
        lineRenderer.transform.rotation = Quaternion.Euler(lineRendererRotation.x, lineRendererRotation.y, lineRendererRotation.z);

    }

    private void SpawnLaserImpactPS(Vector3 aHitPosition, Vector3 aHitRotation) {

        //print("vec: " + aHitRotation);
        Quaternion quaternion = new Quaternion(aHitRotation.x, aHitRotation.y, aHitRotation.z, 0);
        //print("quat: " + quaternion);
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
