using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInWater : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.TryGetComponent(out Rigidbody ball))
        {
            ball.AddForce(Vector3.up * (ball.mass * 7.5f));
        }
    }
}
