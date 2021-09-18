using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectlie : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
}
