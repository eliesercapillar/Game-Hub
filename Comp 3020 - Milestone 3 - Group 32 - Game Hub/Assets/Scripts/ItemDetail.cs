using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetail : MonoBehaviour
{
    public Image coverArt;
    public TMP_Text titleTxt;
    public Image rating;
    public TMP_Text price;
    public TMP_Text description;

    public ShopItemSO item;

    void Start()
    {
        populateScreen();
    }

    public void populateScreen()
    {
        coverArt.sprite = item.art2;
        titleTxt.text = item.title;
        rating.sprite = item.rating;
        price.text = "$" + item.price;
        description.text = item.description;
    }

    public void addToBag()
    {

    }
}
