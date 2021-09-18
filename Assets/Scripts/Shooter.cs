using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;

    //shoots projectile from the position of the gun
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
