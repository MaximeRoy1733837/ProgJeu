
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerHealthSystem : MonoBehaviour {
    public Death death;
    private float playerHealth = 100f;
    private float playerHealingRate = 25f;
    private float playerMaxHealth = 100f;
    private bool isDead = false;

    private AudioClip audioClipHurt;
    private AudioSource audioSource;
    private UnityEngine.UI.Image bloodOverlay;
    private Color bloodOverlayColor;

    public float PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public float PlayerMaxHealth { get => playerMaxHealth; set => playerMaxHealth = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    private void Start()
    {
        death = GameObject.FindObjectOfType<Death>();
    }

    private void Update() {

        this.Heal(playerHealingRate * Time.deltaTime);
        
    }

    public void Initialize(float aHealth, float aMaxHealth) {

        this.playerHealth = aHealth;
        this.playerMaxHealth = aMaxHealth;
        this.audioClipHurt = Resources.Load<AudioClip>("Sound/hurt");
        this.audioSource = gameObject.GetComponent<AudioSource>();
        this.bloodOverlay = GameObject.Find("BloodOverlay").GetComponent<UnityEngine.UI.Image>();
        this.bloodOverlayColor = GameObject.Find("BloodOverlay").GetComponent<UnityEngine.UI.Image>().color;
    }
    public void Heal(float aHealAmount) {

        bloodOverlayColor.a = (1 - (this.playerHealth / this.playerMaxHealth));
        this.bloodOverlay.color = this.bloodOverlayColor;

        if (this.playerHealth < 100f && !this.isDead) {

            if (this.playerHealth + aHealAmount < this.playerMaxHealth) {

                this.playerHealth += aHealAmount;

            } else {

                this.playerHealth = this.playerMaxHealth;
            }
        }
    }
    public void Damage(float aDamageAmount) {

        this.bloodOverlayColor.a = 1 - (this.playerHealth / this.playerMaxHealth);
        this.bloodOverlay.color = this.bloodOverlayColor;
        this.audioSource.PlayOneShot(this.audioClipHurt, 1f);

        if (this.playerHealth > 0f && !this.isDead) {

            if (this.playerHealth - aDamageAmount > 0f) {

                this.playerHealth -= aDamageAmount;

            } else {

                this.playerHealth = 0f;
                death.ReSpawn();

                this.playerHealth = playerMaxHealth;
            }
        }
    }


}
