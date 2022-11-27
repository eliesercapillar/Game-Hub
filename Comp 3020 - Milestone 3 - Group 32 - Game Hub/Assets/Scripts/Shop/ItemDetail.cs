using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    void Awake()
    {
        string title = DataPersistency.getItemToShowDetailFor();

        foreach (ShopItemSO so in Resources.FindObjectsOfTypeAll<ShopItemSO>())
        {
            if (title == so.title)
            {
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
        titleTxt.text = item.title;
        rating.sprite = item.rating;
        price.text = "$" + item.price;
        description.text = item.description;
    }

    public void addToBag()
    {
        Debug.Log("Added to bag");
    }

    public void goBack()
    {
        string genre = DataPersistency.getTheItemGenre();
        SceneManager.LoadScene(genre + " SHOP MENU");
    }
}
