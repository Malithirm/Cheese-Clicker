using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void Update()
    {
        Vector2 newPosition = new Vector2(transform.position.x, (Random.Range(665f, 680f)));
        transform.position = newPosition;
    }
}
