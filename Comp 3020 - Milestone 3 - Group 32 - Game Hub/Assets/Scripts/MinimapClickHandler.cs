using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinimapClickHandler : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject enlargedMap;

    private bool currentlyShowingMap;
    private GameObject theMap;

    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;
    void Awake()
    {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Start()
    {
        currentlyShowingMap = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Casting Raycast");
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            Debug.Log("Comparing Raycast");
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            bool weHit = false;
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "Minimap")
                {
                    Debug.Log("We hit the map");
                    weHit = true;
                    if (!currentlyShowingMap)
                    {
                        showMap();
                    }
                }
            }

            if (!weHit && currentlyShowingMap)
            {
                destroyMap();
            }
        }
    }

    private void showMap()
    {
        currentlyShowingMap = true;
        theMap = Instantiate(enlargedMap);
        theMap.GetComponent<Transform>().SetParent(parent);

        RectTransform mapTransform = theMap.GetComponent<RectTransform>();

        mapTransform.anchoredPosition = new Vector2(0, 0);
    }

    private void destroyMap()
    {
        Destroy(theMap);
        currentlyShowingMap = false;
    }
}
