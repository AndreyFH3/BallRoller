using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{

    [SerializeField]private Manager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rotator rotator))
        {
            rotator.gameObject.SetActive(false);
            ++manager.Amount;
        }
    }
}
