using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class PauseActivate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Button pauseBtn;
    [SerializeField] private OnScreenButton pauseButton;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    

    private void SetPause()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
