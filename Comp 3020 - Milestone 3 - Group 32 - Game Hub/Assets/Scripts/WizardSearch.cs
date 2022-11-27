using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WizardSearch : MonoBehaviour
{
    public SOso allSOs;

    public GameObject prefab;
    public RectTransform parent;

    private List<GameObject> GOs;

    public TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        GOs = new List<GameObject>();

        populate();
    }

    private void populate()
    {
        foreach (ShopItemSO so in allSOs.shopItems)
        {
            GameObject element = Instantiate(prefab, parent);

            GOs.Add(element);

            element.GetComponent<CardBehaviour>().setSO(so);

            ShopTemplate sT = element.GetComponent<ShopTemplate>();

            sT.titleTxt.text = so.title;
            sT.art.sprite = so.art;
            sT.rating.sprite = so.rating;
        }
    }
    
    public void search()
    {
        string searchText = input.text;
        int searchTxtLength = searchText.Length;

        foreach (GameObject go in GOs)
        {
            ShopTemplate sT = go.GetComponent<ShopTemplate>();
            if (sT.titleTxt.text.Length >= searchTxtLength)
            {
                if (searchText.ToLower() == sT.titleTxt.text.Substring(0, searchTxtLength).ToLower())
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }
            }
        }
    }
}
