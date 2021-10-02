using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    //subtract health when the attacker reaches the end, then destroy the attacker
    private void OnTriggerEnter2D(Collider2D attacker)
    {
        var healthDisplay = FindObjectOfType<HealthDisplay>();
        healthDisplay.SubtractHealth();
        Destroy(attacker.gameObject);
    }
}
