using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromBag : MonoBehaviour
{
    private BagManager bm;

    private void Awake()
    {
        GameObject go = GameObject.Find("Backpack Container");
        bm = go.GetComponent<BagManager>();
    }

    public void onClickX()
    {
        bm.removeItemFromBag(this.gameObject);
    }

}
