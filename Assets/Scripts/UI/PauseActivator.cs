using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseActivator : MonoBehaviour
{
    [SerializeField] private GameObject pauseObj;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void OnEnable()
    {
        btn.onClick.AddListener(() =>
        {
            pauseObj.SetActive(true);
            Time.timeScale = 0;
        });
    }
    private void OnDisable()
    {
        btn.onClick.RemoveAllListeners();
    }
}
