﻿// Magica Cloth 2.
// Copyright (c) 2023 MagicaSoft.
// https://magicasoft.jp
using UnityEditor;
using UnityEngine;

namespace MagicaCloth2
{
    /// <summary>
    /// Aboutダイアログ
    /// </summary>
    public class AboutMenu : EditorWindow
    {
        [SerializeField]
        private Texture2D image = null;

        public const string MagicaClothVersion = "2.16.1";

        public static AboutMenu AboutWindow { get; set; }
        private const float windowWidth = 300;
        private const float windowHeight = 220;

        private const string webUrl = "https://magicasoft.jp/en/magica-cloth-2-2/";

        //=========================================================================================
        [MenuItem("Tools/Magica Cloth2/About", false)]
        static void InitWindow()
        {
            if (AboutWindow)
                return;
            AboutWindow = CreateInstance<AboutMenu>();
            AboutWindow.position = new Rect(Screen.width / 2, Screen.height / 2, windowWidth, windowHeight);
            AboutWindow.minSize = new Vector2(windowWidth, windowHeight);
            AboutWindow.maxSize = new Vector2(windowWidth, windowHeight);
            AboutWindow.titleContent.text = "About Magica Cloth 2";
            AboutWindow.ShowUtility();
        }

        //=========================================================================================
        private void Awake()
        {
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void OnDestroy()
        {
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUIStyle myStyle = new GUIStyle();
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 20;
            myStyle.normal.textColor = Color.white;

            GUILayout.Box(image, myStyle);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Magica Cloth 2", myStyle);

            EditorGUILayout.Space(5);
            myStyle.fontSize = 16;
            EditorGUILayout.LabelField($"version {MagicaClothVersion}", myStyle);

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            myStyle.fontSize = 12;
            EditorGUILayout.LabelField("Copyright © Magica Soft", myStyle);
            EditorGUILayout.LabelField("All Rights Reserved", myStyle);

            //EditorGUILayout.LabelField(webUrl, myStyle);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            using (var h = new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.Space();
                if (GUILayout.Button("Website"))
                {
                    Application.OpenURL(webUrl);
                }

                EditorGUILayout.Space();

                if (GUILayout.Button("Close"))
                {
                    Close();
                }

                EditorGUILayout.Space();
            }
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }
    }
}
