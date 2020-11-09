using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private AudioSource hurtSound;
    public AudioClip hurtSoundClip;

    private CharacterController characterController;
    private PlayerHealthSystem playerHealthSystem;
    private float TPCooldown = 0f;

    void Start()
    {
        hurtSound = gameObject.GetComponent<AudioSource>();
        characterController = gameObject.GetComponent<CharacterController>();
        playerHealthSystem = gameObject.AddComponent<PlayerHealthSystem>();
        playerHealthSystem.Initialize(100, 100);
    }

    void Update()
    {
        TPCooldown -= Time.deltaTime;
        //playerDamageCooldown -= Time.deltaTime;
        //playerHealthSystem.Heal(playerHealingRate * Time.deltaTime);
        //Debug.Log(playerHealthSystem.PlayerHealth);
        
    }

    void OnTriggerEnter(Collider collider) {

        if (collider.tag == "Portal" && TPCooldown <= 0) {

            TPCooldown = 0.05f;
            SelfPortal portal = collider.GetComponentInParent<SelfPortal>();

            if (portal != null) {

                PortalManager portalManager = portal.getPortalManager();

                if (portalManager != null) {

                    characterController.enabled = false;
                    portalManager.GetTpTransform(transform, transform);
                    characterController.enabled = true;
                }
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {

        //if (playerDamageCooldown <= 0) {

            //if (hit.transform.tag == "Trap_pikes_small") {

                //playerDamageCooldown = 0.5f;
                //playerHealthSystem.Damage(0.1f);
                //print("player health: " + playerHealthSystem.PlayerHealth);

            //}
        //}
    }

}
