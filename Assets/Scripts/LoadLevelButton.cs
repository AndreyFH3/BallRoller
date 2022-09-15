using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using YG;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class LoadLevelButton : MonoBehaviour
{
    [SerializeField] private GameObject loadingCanvas;
    enum ButtonType { ResumeGameLastLevel = 0, LoadLevelSelectedlevel = 1 }
    [SerializeField, HideInInspector] private Image[] stars;
    [SerializeField, HideInInspector] private int levelIndexToLoad;
    [SerializeField] private ButtonType buttonType;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if(buttonType == ButtonType.ResumeGameLastLevel)
            button.onClick.AddListener(() => LevelLoad(YandexGame.savesData.lastLevelIndex));
        else
            button.onClick.AddListener(() => LevelLoad(levelIndexToLoad));
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    private void LevelLoad(int index)
    {
        GameObject canvas = Instantiate(loadingCanvas);
        StartCoroutine(canvas.GetComponent<loadCanvas>().loadLevelAsync(index));
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(LoadLevelButton))]
    public class LoadLevelButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LoadLevelButton load = (LoadLevelButton)target;

            if(load.buttonType == ButtonType.LoadLevelSelectedlevel)
            {
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty(nameof(load.stars)),
                        new GUIContent("Stars")
                );

                EditorGUILayout.LabelField("Level Index" ,GUILayout.MaxWidth(50));
                load.levelIndexToLoad = EditorGUILayout.IntField(load.levelIndexToLoad);
            }
            EditorUtility.SetDirty(load);
        }
    }
#endif
}
