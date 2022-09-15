using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablerInputScreen : MonoBehaviour
{
    private void Start()
    {
        if(YG.YandexGame.EnvironmentData.isMobile || YG.YandexGame.EnvironmentData.isTablet)
            return;
        else gameObject.SetActive(false);
    }
}
