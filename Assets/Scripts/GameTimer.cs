using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        //stop checking the time left in the level once we've reached the end of the set time
        if(triggeredLevelFinished) { return; }

        //Slider progress will be based on the amount of time left in level
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        //when the player has reached the time we set for this level, end the level
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
