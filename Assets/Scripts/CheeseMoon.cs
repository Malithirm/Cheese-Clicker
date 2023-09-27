using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheeseMoon : MonoBehaviour
{
    public float _rotationSpeed = 8.5f;
    public int CheeseAmount;
    [SerializeField] private TextMeshProUGUI _cheeseText;

    void Update()
    {
        _cheeseText.text = $"Cheesium: \n{CheeseAmount.ToString()}";

        transform.Rotate(Vector3.back, Time.deltaTime * _rotationSpeed);
    }

    public void IncrementCheesium()
    {
        CheeseAmount++;
    }
}
