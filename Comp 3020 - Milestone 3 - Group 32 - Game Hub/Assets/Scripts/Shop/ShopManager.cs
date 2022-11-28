using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels1;
    public ShopTemplate[] shopPanels2;
    public ShopTemplate[] shopPanels3;
    public ShopTemplate[] shopPanels4;
    public ShopTemplate[] shopPanels5;
    public GameObject[] shopPanelsGO1;
    public GameObject[] shopPanelsGO2;
    public GameObject[] shopPanelsGO3;
    public GameObject[] shopPanelsGO4;
    public GameObject[] shopPanelsGO5;

    public GameObject addedIMG;

    public TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        setAllActive();
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO1[i].GetComponent<CardBehaviour>().setSO(shopItemsSO[i]);
            shopPanelsGO2[i].GetComponent<CardBehaviour>().setSO(shopItemsSO[i]);
            shopPanelsGO3[i].GetComponent<CardBehaviour>().setSO(shopItemsSO[i]);
            shopPanelsGO4[i].GetComponent<CardBehaviour>().setSO(shopItemsSO[i]);
            shopPanelsGO5[i].GetComponent<CardBehaviour>().setSO(shopItemsSO[i]);
        }
        LoadPanels();
    }

    public void Search()
    {
        string searchText = input.text;
        int searchTxtLength = searchText.Length;

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopPanels1[i].titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == shopPanels1[i].titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    shopPanelsGO1[i].SetActive(true);
                }
                else
                {
                    shopPanelsGO1[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopPanels2[i].titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == shopPanels2[i].titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    shopPanelsGO2[i].SetActive(true);
                }
                else
                {
                    shopPanelsGO2[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopPanels3[i].titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == shopPanels3[i].titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    shopPanelsGO3[i].SetActive(true);
                }
                else
                {
                    shopPanelsGO3[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopPanels4[i].titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == shopPanels4[i].titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    shopPanelsGO4[i].SetActive(true);
                }
                else
                {
                    shopPanelsGO4[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopPanels5[i].titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == shopPanels5[i].titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    shopPanelsGO5[i].SetActive(true);
                }
                else
                {
                    shopPanelsGO5[i].SetActive(false);
                }
            }
        }
    }

    private void setAllActive()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO1[i].SetActive(true);

            shopPanelsGO2[i].SetActive(true);

            shopPanelsGO3[i].SetActive(true);

            shopPanelsGO4[i].SetActive(true);

            shopPanelsGO5[i].SetActive(true);
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels1[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels1[i].art.sprite = shopItemsSO[i].art;
            shopPanels1[i].rating.sprite = shopItemsSO[i].rating;

            shopPanels2[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels2[i].art.sprite = shopItemsSO[i].art;
            shopPanels2[i].rating.sprite = shopItemsSO[i].rating;

            shopPanels3[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels3[i].art.sprite = shopItemsSO[i].art;
            shopPanels3[i].rating.sprite = shopItemsSO[i].rating;

            shopPanels4[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels4[i].art.sprite = shopItemsSO[i].art;
            shopPanels4[i].rating.sprite = shopItemsSO[i].rating;

            shopPanels5[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels5[i].art.sprite = shopItemsSO[i].art;
            shopPanels5[i].rating.sprite = shopItemsSO[i].rating;
        }
    }

    public void showMSG(bool b)
    {
        addedIMG.SetActive(b);
    }
}
