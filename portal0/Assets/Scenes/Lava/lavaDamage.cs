using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaDamage : MonoBehaviour
{
    private float playerDamageCooldown = 0.5f;
    private float playerDamageCooldownValue = 0.5f;
    public float trapDamage = 30f;
    // Start is called before the first frame update
    void Start()
    {          
    }

    // Update is called once per frame
    void Update()
    {
        playerDamageCooldownValue -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.transform.tag);
        //print("toucher");
        if (playerDamageCooldownValue <= 0)
        {
            if (other.transform.tag == "Player")
            {
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Damage(trapDamage);
                playerDamageCooldownValue = playerDamageCooldown;

            }
        }

    }
}
