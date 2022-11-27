using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;


public class ItemDetail : MonoBehaviour
{
    public Image coverArt;
    public TMP_Text titleTxt;
    public Image rating;
    public TMP_Text price;
    public TMP_Text description;

    public ShopItemSO item;

    public SOso allSOs;


    void Awake()
    {
        string title = DataPersistency.getItemToShowDetailFor();
        Debug.Log("Retrieving Playerpref: " + title);

        Debug.Log(Resources.FindObjectsOfTypeAll<ShopItemSO>().Length);
        foreach (ShopItemSO so in allSOs.shopItems)
        {
            Debug.Log("comparing " + title + " to " + so.title);
            if (title == so.title)
            {
                Debug.Log("Title is: " + title);
                Debug.Log("so Title is " + so.title);
                item = so;
                return;
            }
        }
    }

    void Start()
    {
        Debug.Log("Populating Screen");
        populateScreen();
    }

    public void populateScreen()
    {
        coverArt.sprite = item.art2;
        Debug.Log(item.title);
        titleTxt.text = item.title;
        rating.sprite = item.rating;
        price.text = "$" + item.price;
        description.text = item.description;
    }

    public void addToBag()
    {
        Debug.Log("Added to backpack");
        Backpack.instance.addToBag(item);
    }

    public void goBack()
    {
        string genre = DataPersistency.getTheItemGenre();
        SceneManager.LoadScene(genre + " SHOP MENU");
    }
}
