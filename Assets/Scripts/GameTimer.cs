using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;

    // Update is called once per frame
    void Update()
    {
        //Slider progress will be based on the amount of time left in level
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        //when the player has reached the time we set for this level, end the level
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            //TODO end level when time has expired
            Debug.Log("Level timer expired!");
        }
    }
}
