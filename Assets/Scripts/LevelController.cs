using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] int winDelay = 5;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    
    private void Start()
    {
        //stops scene from displaying the win message at the start of the game
        winLabel.SetActive(false);
    }

    //keeps track of the number of Attackers on screen; add one when an attacker spawns
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    //keeps track of the number of Attackers on screen; subtract one when an attacker is killed
    //win condition is met when there are no more attackers and the level timer is finished
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 &&  levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    //play win audio, display win message, then load the next level after a short delay
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        GetComponent<LevelLoader>().LoadNextScene();
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
