using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeTrapDamage : MonoBehaviour
{
    private float playerDamageCooldown = 0.1f;
    private float playerDamageCooldownValue = 0.1f;
    public float trapDamage = 90f;

    void Update() {

        playerDamageCooldownValue -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other) {
        
        if (playerDamageCooldownValue <= 0) {
            if (other.transform.tag == "Player") {

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Damage(trapDamage);
                playerDamageCooldownValue = playerDamageCooldown;

            }
        }

    }
}
