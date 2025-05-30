using System.Collections;
using Common.Data;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTools
{
    [MenuItem("Map Tools/Export Teleporters")]
    public static void ExportTeleporters()
    {
        DataManager.Instance.Load();

        Scene current = EditorSceneManager.GetActiveScene();
        string currentScene = current.name;
        if (current.isDirty)
        {
            EditorUtility.DisplayDialog("��ʾ", "���ȱ��浱ǰ����", "ȷ��");
            return;
        }

        List<TeleporterObject> allTeleporters = new List<TeleporterObject>();

        foreach (var map in DataManager.Instance.Maps)
        {
            string sceneFile = "Assets/Levels/" + map.Value.Resource + ".unity";
            if (!System.IO.File.Exists(sceneFile))
            {
                Debug.LogWarningFormat("Scene {0} not existed!", sceneFile);
                continue;
            }
            EditorSceneManager.OpenScene(sceneFile, OpenSceneMode.Single);

            TeleporterObject[] teleporters = GameObject.FindObjectsOfType<TeleporterObject>();
            foreach (var teleporter in teleporters)
            {
                if (!DataManager.Instance.Teleporters.ContainsKey(teleporter.ID))
                {
                    EditorUtility.DisplayDialog("����", string.Format("��ͼ��{0} �����õ� Teleporter��[{1}] �в�����", map.Value.Resource, teleporter.ID), "ȷ��");
                    return;
                }

                TeleporterDefine def = DataManager.Instance.Teleporters[teleporter.ID];
                if (def.MapID != map.Value.ID)
                {
                    EditorUtility.DisplayDialog("����", string.Format("��ͼ��{0} �����õ� Teleporter��[{1}] MapID��{2} ����", map.Value.Resource, teleporter.ID, def.MapID), "ȷ��");
                    return;
                }
                def.Position = GameObjectTool.WorldToLogicN(teleporter.transform.position);
                def.Direction = GameObjectTool.WorldToLogicN(teleporter.transform.forward);
            }
        }
        DataManager.Instance.SaveTeleporters();
        EditorSceneManager.OpenScene("Assets/Levels/" + currentScene + ".unity");
        EditorUtility.DisplayDialog("��ʾ", "���͵㵼�����", "ȷ��");
    }
}
