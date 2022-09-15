using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private UIControl ui;
    [SerializeField] private float stars1;
    [SerializeField] private float stars2;
    [SerializeField] private float stars3;

    private int _amount;
    private int _counter;
    public int Counter { get => _counter; set => _counter = value; }
    
    public int Amount { get => _amount; set 
        {
            _amount = value; 
            ui.SetMoneytext(_amount); 
            if(_counter <= _amount)
            {
                ui.disableTimer();
            }
        } 
    }


}
