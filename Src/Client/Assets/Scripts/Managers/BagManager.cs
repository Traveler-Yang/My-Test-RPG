using Managers;
using Models;
using SkillBridge.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class BagManager : Singleton<BagManager>
{

    public int Unlocked;

    public BagItem[] items;

    NBagInfo Info;

    unsafe public void Init(NBagInfo info)
    {
        this.Info = info;
        this.Unlocked = info.Unlocked;
        items = new BagItem[this.Unlocked];
        if (info.Items != null && info.Items.Length >= this.Unlocked)
        {
            Analyze(info.Items);
        }
        else
        {
            info.Items = new byte[sizeof(BagItem) * this.Unlocked];
            Reset();
        }
    }

    private void Reset()
    {
        int i = 0;
        foreach (var kv in ItemManager.Instance.Items)
        {
            if (kv.Value.Count <= kv.Value.define.StackLimit)
            {
                this.items[i].ItemId = (ushort)kv.Key;
                this.items[i].Count = (ushort)kv.Value.Count;
            }
            else
            {
                int count = kv.Value.Count;
                while (count > kv.Value.define.StackLimit)
                {

                }
            }
        }
    }

    unsafe void Analyze(byte[] data)
    {
        //����һ��byte���͵�ָ�룬��ָ��data����ĵ�һλ���ڴ��ַ
        fixed (byte* pt = data)
        {
            //�������������и���
            for (int i = 0; i < Unlocked; i++)
            {
                //sizeof(BagItem)�ǵ�ǰ��Ʒ���ڴ�����ռ���ֽ���
                //i * sizeof(BagItem) ��������ǵ�i����Ʒ������ڴ��е���ʼƫ��
                //Ҳ������Ҫ�������ڴ�
                //��ǰ���(BagItem*)(pt + i * sizeof(BagItem))�������
                //pt����ָ�򱳰�����ĵ�һλ�ĵ�ַ
                //pt + i��Ҫ�������ٸ��ֽڿ飬�������i * sizeof(BagItem)������Ҫ�������ֽڴ�С
                //����������ǴӴӵ�һλ��ַ��ʼ���������ٸ� BagItem��С�� �ֽڿ�
                //�����õ�������ڴ棬ת��(ǿת)�� BagItem* ���ͣ��洢����
                BagItem* item = (BagItem*)(pt + i * sizeof(BagItem));
                //�����ǽ�����洢���ڴ棬���뱳���ĸ���
                items[i] = *item;
            }
        }
    }

    unsafe public NBagInfo GetBagInfo()
    {
        //����ͬ��
        fixed (byte* pt = Info.Items)
        {
            for (int i = 0; i < Unlocked; i++)
            {
                BagItem* item = (BagItem*)(pt + i * sizeof(BagItem));
                items[i] = *item;
            }
        }
        return this.Info;
    }
}
