using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class UIControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject[] stars;

    private float timer;
    private bool isWin = false;
    public void SetMoneytext(int money) => moneyText.text = $"Собрано: {money}";
    
    private void Start()
    {
        SetMoneytext(0);    
    }
    
    private void Update()
    {
        if (!isWin)
        {
            timer += Time.deltaTime;
            time.text = $"Время прохождения: { Mathf.Round(timer)} секунд";
        }

    }

    private void reloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex < SceneManager.sceneCountInBuildSettings-1 ? sceneIndex + 1 : 1);
    }
    public void disableTimer()
    {
        isWin = true;
        Win.SetActive(true);
        time.text = (Mathf.Round(timer)).ToString();
        Invoke(nameof(reloadLevel), 5f);


    }

    public void SetStars(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            this.stars[i].SetActive(true);
        }
        int levelindex = SceneManager.GetActiveScene().buildIndex;
        YandexGame.savesData.stars[levelindex - 1].stars = stars;
        YandexGame.savesData.openLevels[levelindex - 1] = true;
        YandexGame.savesData.lastLevelIndex = levelindex;
        YandexGame.SaveProgress();
    }

}
