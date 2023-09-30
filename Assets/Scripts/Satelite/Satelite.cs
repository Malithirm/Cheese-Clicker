using UnityEngine;

public class Satelite : MonoBehaviour
{
    public float _orbitSpeed = 30f;
    private Vector3 orbitAxis;
    [HideInInspector] [SerializeField] private Transform _cheeseMoon;

    private void Start()
    {
        orbitAxis = Vector3.Cross(Vector3.up, transform.position - _cheeseMoon.position);

    }

    void Update()
    {
        transform.RotateAround(_cheeseMoon.position, orbitAxis, _orbitSpeed * Time.deltaTime);

    }
}
