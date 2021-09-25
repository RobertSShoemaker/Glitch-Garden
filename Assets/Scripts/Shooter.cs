using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;


    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if an attacker is in the lane then start the attack animation, else start the idle animation
        if (IsAttackerInLane())
        {
            //isAttacking was setup on the animation controller transitions
            animator.SetBool("isAttacking", true);

        } 
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }


    //determines the lane of an attacker's spawner
    //only need to determine this once, since the other attacker's from this lane will have the same location
    private void SetLaneSpawner()
    {
        //array of all attack spawners
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        //find this lane's corresponding spawner
        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            //determines whether the attacker's spawner and defender(shooter) are in the same lane
            //finds the difference of the attacker's spawner and defender's y positions; if it's less than or equal to epsilon then they are in the same lane
            //epsilon is the smallest float value bigger than 0
            //need absolute value since the y values can be negative
            bool IsCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                //only one spawner per lane
                myLaneSpawner = attackerSpawner;
            }
        }
    }

    //determine if an attacker is in the same lane as the defender
    private bool IsAttackerInLane()
    {
        //if there are no attacker children in the spawner for this lane, then return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //shoots projectile from the position of the gun
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
