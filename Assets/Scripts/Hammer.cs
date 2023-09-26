using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void Update()
    {
        Vector2 newPosition = new Vector2(transform.position.x, (Random.Range(675f, 680f)));
        transform.position = newPosition;
    }
}
