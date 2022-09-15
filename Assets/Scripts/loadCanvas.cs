using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class loadCanvas : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI percentText;

    public IEnumerator loadLevelAsync(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        while (asyncLoad.isDone)
        {
            float percents = asyncLoad.progress / .9f * 100;
            fillImage.fillAmount = percents;
            percentText.text = $"{percents}%"; 
            yield return null;
        }
    }
}
