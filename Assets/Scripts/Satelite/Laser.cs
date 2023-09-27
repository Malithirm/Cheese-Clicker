using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float _rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);

    }
}
