using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : UIWindow
{
    public Text testText; // ������ʾ�����ı�

    void Start()
    {

    }

    public void Set(string title)
    {
        this.testText.text = title;
    }
    
    void Update()
    {
        
    }
}
