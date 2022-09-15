using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _followSpeed;
    private Vector3 offset;
    
    private void Start()
    {
        offset = transform.position - ballTransform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {


        transform.position = Vector3.Lerp(transform.position, ballTransform.position + offset, _followSpeed * Time.deltaTime);

    }
}
