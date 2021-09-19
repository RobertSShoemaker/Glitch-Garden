using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;

    [SerializeField] GameObject deathVFX;

    Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    //Process damage taken
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeathVFX();
            Destroy(gameObject);
        }
    }
    //Death visual effects
    private void DeathVFX()
    {
        if(!deathVFX) { return; }
        //position will set the death animation to the location of the collider, otherwise the death animation will be in the wrong position
        //this is because the lizard sprite is not centered due to intro animation
        Vector2 position = (Vector2)transform.position + myCollider.offset;

        GameObject deathVFXObject = Instantiate(deathVFX, position, transform.rotation);
        Destroy(deathVFXObject, deathVFX.GetComponent<ParticleSystem>().main.duration);
    }
}
