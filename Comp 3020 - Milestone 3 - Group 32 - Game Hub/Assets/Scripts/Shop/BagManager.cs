using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BagManager : MonoBehaviour
{
    private Backpack backpack;

    public GameObject prefab;
    public RectTransform parent;

    public GameObject thankYou;

    public Button checkoutBtn;

    private float total;
    public TMP_Text cost;

    private List<GameObject> GOs;

    void Awake()
    {
        backpack = Backpack.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        GOs = new List<GameObject>();
        displayBag();
    }
    void Update()
    {
        if (total <= 0)
        {
            checkoutBtn.interactable = false;
        }
        else
        {
            checkoutBtn.interactable = true;
        }
    }

    private void displayBag()
    {
        foreach (ShopItemSO so in backpack.getItems())
        {
            GameObject element = Instantiate(prefab, parent);

            GOs.Add(element);

            BagTemplate bt = element.GetComponent<BagTemplate>();

            bt.titleTxt.text = so.title;
            bt.art.sprite = so.art;
            bt.priceTxt.text = "$" + so.price;
            total += so.price;
        }
        cost.text = "$" + total;
    }

    public void goBack()
    {
        string theScene = DataPersistency.getPriorBPScene();

        SceneManager.LoadScene(theScene);
    }

    public void checkout()
    {
        backpack.destroyBag();
        total = 0;
        cost.text = "$" + total;

        foreach (GameObject go in GOs)
        {
            Destroy(go);
        }

        thankYou.SetActive(true);
        StartCoroutine(WaitTwoSecs());
    }

    private IEnumerator WaitTwoSecs()
    {
        yield return new WaitForSeconds(2f);
        thankYou.SetActive(false);
    }
}
