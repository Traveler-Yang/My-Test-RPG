using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    /// <summary>
    /// UI�����Ϣ
    /// </summary>
    class UIElement
    {
        public string Resource;     //��Դ·��
        public bool cache;          //�Ƿ񻺴�
        public GameObject instance; //UIʵ��
    }
    /// <summary>
    /// �洢UI��Դ��Ϣ
    /// </summary>
    private Dictionary<Type, UIElement> UIResources = new Dictionary<Type, UIElement>();

    /// <summary>
    /// ��UI����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Show<T>()
    {
        //���UI�Ƿ��Ѿ���
        Type type = typeof(T);
        if (UIResources.ContainsKey(type))
        {

        }
        return default(T);
    }

    /// <summary>
    /// �ر�UI����
    /// </summary>
    public void Colse()
    {

    }
}
