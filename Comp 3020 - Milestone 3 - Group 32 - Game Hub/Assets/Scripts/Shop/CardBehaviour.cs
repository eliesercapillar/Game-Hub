using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardBehaviour : MonoBehaviour
{
    public ShopItemSO item;
    public void moreDetails()
    {
        DataPersistency.setItemToShowDetailFor(item.title);
        DataPersistency.setTheItemGenre(item.genre);
        SceneManager.LoadScene("ITEM DETAIL");
    }

    public void addToBag()
    {

    }

    public void setSO(ShopItemSO so)
    {
        item = so;
    }
}
