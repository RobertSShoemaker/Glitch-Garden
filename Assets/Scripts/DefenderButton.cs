using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    //Clicking the defender in the menu will highlight it and set it as the selected defender
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            //reset all of the defender buttons to be greyed out whenever a button is clicked
            button.GetComponent<SpriteRenderer>().color = new Color32(60, 59, 59, 255);
        }
        //set the defender clicked to white i.e. highlight it
        GetComponent<SpriteRenderer>().color = Color.white;
        //select the defender clicked
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
