using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    Attacker attacker;
    bool spawn = true;
    

    //add a 1-5 second delay between spawning enemies
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    //spawn the attacker randomly from the array of attackers
    private void SpawnAttacker()
    {
        int randomAttacker = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[randomAttacker]);
    }

    //instantiate the attacker
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

   
}
