using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    //adds 1 to the number of attackers as soon as Attacker is created
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    //subtracts 1 from the number of attacekrs as soon as Attacker is destroyed
    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }


    void Update()
    {
        //make enemy move from right to left
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }


    //set movement speed
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //changes animation to attacking and sets the currentTarget to the game object it's attacking
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }

    }
}
