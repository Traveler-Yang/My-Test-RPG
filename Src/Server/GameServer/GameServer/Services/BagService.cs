﻿using Common;
using GameServer.Entities;
using Network;
using SkillBridge.Message;

namespace GameServer.Services
{
    class BagService
    {
         public BagService()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<BagSaveRequest>(this.OnBagSave);
        }

        public void Init()
        {

        }

        private void OnBagSave(NetConnection<NetSession> sender, BagSaveRequest request)
        {
            Character character = sender.Session.Character;

            Log.InfoFormat("BagSaveRequest：：Character：{0}：Unlocked{1}", character.Id, request.BagInfo.Unlocked);

            if (request.BagInfo != null)
            {
                character.Data.Bag.Items = request.BagInfo.Items;
                DBService.Instance.Save();
            }
        }
    }
}
