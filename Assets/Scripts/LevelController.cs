using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 &&  levelTimerFinished)
        {
            Debug.Log("End level Now!");
        }
    }

    //stops spawning attackers when the time runs out; called by GameTimer
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    //stops all of the Attacker Spawners in the level
    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
