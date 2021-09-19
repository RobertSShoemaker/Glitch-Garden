using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        
        SpawnDefender(GetSquareClicked());

    }

    //Gets the position where the mouse was clicked
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    //Spawns a defender at the location where mouse was clicked
    private void SpawnDefender(Vector2 position)
    {
        GameObject newDefender = Instantiate(defender, position, Quaternion.identity) as GameObject;
    }
}
