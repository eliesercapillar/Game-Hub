using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardBehaviour : MonoBehaviour
{
    public ShopItemSO item;
    public ShopManager sm;

    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopManager>();
    }

    public void moreDetails()
    {
        Debug.Log("Setting playerpref: " + item.title);
        DataPersistency.setItemToShowDetailFor(item.title);
        DataPersistency.setTheItemGenre(item.genre);
        SceneManager.LoadScene("ITEM DETAIL");
    }

    public void addToBag()
    {
        Backpack.instance.addToBag(item);
        StartCoroutine(showBoughtMSG());
    }

    public void setSO(ShopItemSO so)
    {
        item = so;
    }

    private IEnumerator showBoughtMSG()
    {
        sm.showMSG(true);
        yield return new WaitForSeconds(1f);
        sm.showMSG(false);
    }
}
