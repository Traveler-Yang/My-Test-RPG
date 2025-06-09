using Common.Data;
using SkillBridge.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class Item : MonoBehaviour
    {
        public int Id;

        public int Count;
        public ItemDefine define;
        public Item(NItemInfo item)
        {
            this.Id = item.Id;
            this.Count = item.Count;
            this.define = DataManager.Instance.Items[item.Id];//��ȡ��ǰ���ߵ�������Ϣ
        }

        public override string ToString()
        {
            return String.Format("ID��{0}��Count��{1}", this.Id, this.Count);
        }
    }
}
