using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Start()
    {
        FindObjectOfType<Manager>().Counter++;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, -_speed * Time.deltaTime, Space.World);
    }
}
