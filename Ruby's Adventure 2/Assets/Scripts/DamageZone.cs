using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 1; // Set the damage amount in the Unity Editor

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the damage zone has a "Player" tag
        if (other.CompareTag("Player"))
        {
            RubyController playerController = other.GetComponent<RubyController>();

            if (playerController != null)
            {
                // Apply 1 damage to the player using the ChangeHealth method in RubyController
                playerController.ChangeHealth(-damageAmount);
            }
        }
    }
}