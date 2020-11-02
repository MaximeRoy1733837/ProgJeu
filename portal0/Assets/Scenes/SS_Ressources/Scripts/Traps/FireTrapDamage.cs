using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapDamage : MonoBehaviour
{
    private float playerDamageCooldown = 0.5f;
    private float playerDamageCooldownValue = 0.5f;
    public float trapDamage = 30f;

    void Update() {

        playerDamageCooldownValue -= Time.deltaTime;

    }

    private void OnTriggerStay(Collider other) {

        if (playerDamageCooldownValue <= 0) {
            if (other.transform.tag == "Player") {

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Damage(trapDamage);
                playerDamageCooldownValue = playerDamageCooldown;

            }
        }

    }
}
