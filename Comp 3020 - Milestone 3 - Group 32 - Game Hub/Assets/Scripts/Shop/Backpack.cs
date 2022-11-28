using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backpack : MonoBehaviour
{
    public static Backpack instance;

    private List<ShopItemSO> SOs = new List<ShopItemSO>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void addToBag(ShopItemSO so)
    {
        if (!SOs.Contains(so))
        {
            SOs.Add(so);
        }
       
    }

    public void removeFromBag(string s)
    {
        foreach (ShopItemSO shop in SOs)
        {
            if (shop.title == s)
            {
                SOs.Remove(shop);
                return;
            }
        }
    }

    public List<ShopItemSO> getItems()
    {
        return SOs;
    }
    public void destroyBag()
    {
        SOs = new List<ShopItemSO>();
    }
}
