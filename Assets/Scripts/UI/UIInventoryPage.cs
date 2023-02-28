//https://www.youtube.com/watch?v=sKlAjbqLdAs&list=PLcRSafycjWFegXSGBBf4fqIKWkHDw_G8D&index=6
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private UIInventoryDescription itemDescription;

    //get index and reference against inventory data
    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image;
    public string title, description;

    public void Awake()
    {
        Hide();
        itemDescription.ResetDescription();
    }

    //add items to inventory
    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++) //double check why am i using an int instead of the size of the array or list or whatever
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
        }
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        itemDescription.SetDescription(image, title, description);
        //select item
        //listOfUIItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
