using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    private Animator animator;
    public virtual System.Type Type { get { return this.GetType(); } }

    /// <summary>
    /// UI���ڵ�Ĭ��ѡ������
    /// </summary>
    public enum UIWindowResult
    {
        None,
        Yes,
        No,
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// �ر�UI����
    /// </summary>
    /// <param name="result"></param>
    public void Close(UIWindowResult result = UIWindowResult.None)
    {
        UIManager.Instance.Colse(this.Type);
    }

    /// <summary>
    /// �ر�UI���ڵ�ȡ����ť����¼�
    /// </summary>
    public virtual void OnCloseClick()
    {
        this.Close();
    }

    /// <summary>
    /// �ر�UI���ڵ�ȷ�ϰ�ť����¼�
    /// </summary>
    public virtual void OnYesClick()
    {
        this.Close(UIWindowResult.Yes);
    }
}
