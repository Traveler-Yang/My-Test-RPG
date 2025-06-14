using Common.Data;
using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UIWindow
{
    public Text title;//����
    public Text money;//��Ǯ

    public GameObject shopItem;//�̶���ƷԤ����
    ShopDefine shop;
    public Transform[] itemRoot;//�̵�ҳ��ĸ��ڵ�

    void Start()
    {
        StartCoroutine(InitItems());
    }

    /// <summary>
    /// ��ʼ���̵�ĵ��߱�
    /// </summary>
    /// <returns></returns>
    IEnumerator InitItems()
    {
        foreach (var kv in DataManager.Instance.ShopItems[shop.ID])
        {
            if (kv.Value.Status > 0)
            {
                GameObject go = Instantiate(shopItem, itemRoot[0]);
                UIShopItem ui = go.GetComponent<UIShopItem>();
                ui.SetShopItem(kv.Key, kv.Value, this);

            }
        }
        yield return null;
    }

    /// <summary>
    /// �����̵�Ļ�������
    /// </summary>
    /// <param name="shop"></param>
    public void SetShop(ShopDefine shop)
    {
        this.shop = shop;
        this.title.text = shop.Name;
        this.money.text = User.Instance.CurrentCharacter.Gold.ToString();
    }

    #region ѡ���ĸ��̵���Ʒ

    private UIShopItem selsecShopItem;
    /// <summary>
    /// ѡ����ĸ���Ʒ�����õ������Ʒ
    /// </summary>
    /// <param name="item">��ǰѡ�����Ʒ</param>
    public void SelectShopItem(UIShopItem item)
    {
        if (selsecShopItem != null)
            selsecShopItem.Selected = false;
        selsecShopItem = item;
    }

    #endregion

    /// <summary>
    /// �������
    /// </summary>
    public void OnClickBuy()
    {
        if (this.selsecShopItem == null)
        {
            MessageBox.Show("��ѡ��Ҫ����ĵ���", "������Ʒ");
            return;
        }
        if (!ShopManager.Instance.BuyItem(this.shop.ID, this.selsecShopItem.ShopItemID))
        {

        }
    }
}
