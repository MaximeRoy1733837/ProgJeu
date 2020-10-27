using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamageSystem : MonoBehaviour
{
    private float playerDamageCooldown = 0.1f;
    private float playerDamageCooldownValue = 0.1f;
    public float trapDamage = 90f;

    private PlayerHealthSystem playerHealthSystem;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDamageCooldownValue -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.transform.tag == "Player" && playerDamageCooldownValue <= 0) {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Damage(trapDamage);
            playerDamageCooldownValue = playerDamageCooldown;

        }

    }
}
