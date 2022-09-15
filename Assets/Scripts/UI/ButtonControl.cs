using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonControl : MonoBehaviour
{
    enum buttonType{ ToMenu = 0, Resume = 1 }

    [SerializeField] private buttonType type;
    [SerializeField, HideInInspector] private GameObject loadCanvas;
    [HideInInspector, SerializeField] private GameObject pause;

    private Button MoveTo;


    private void Awake()
    {
        MoveTo = GetComponent<Button>();
    }

    private void OnEnable()
    {
        switch (type)
        {
            case buttonType.ToMenu: 
                MoveTo.onClick.AddListener(ToMenu);
                break;
            case buttonType.Resume: 
                MoveTo.onClick.AddListener(Resume);
                break;
        }
    }

    private void OnDisable()
    {
        MoveTo.onClick.RemoveAllListeners();
    }

    private void ToMenu()
    {
        Time.timeScale = 1;

        GameObject canvas = Instantiate(loadCanvas);
        StartCoroutine(canvas.GetComponent<loadCanvas>().loadLevelAsync(0));
    }

    private void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ButtonControl))]
    public class ButtonControlEditor : Editor
    {
        private ButtonControl buttonControl;
        private void Awake()
        {
            buttonControl = (ButtonControl)target;
        }
        public override void OnInspectorGUI()
        {
            

            base.OnInspectorGUI();
            serializedObject.Update();

            

            if (buttonControl.type == buttonType.ToMenu)
            { 
                //buttonControl.loadingCanvas = serializedObject.FindProperty(nameof(buttonControl.loadingCanvas));
                buttonControl.loadCanvas = EditorGUILayout.ObjectField("Load Canvas",buttonControl.loadCanvas, typeof(GameObject), false) as GameObject;
            }

            else if (buttonControl.type == buttonType.Resume)
            {
                buttonControl.pause = EditorGUILayout.ObjectField("Pause Game Object",buttonControl.pause, typeof(GameObject), true) as GameObject;

            }
            EditorUtility.SetDirty(buttonControl); // если нажо из сцены брать
            //PrefabUtility.RecordPrefabInstancePropertyModifications(buttonControl); еслин надо префаб
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
