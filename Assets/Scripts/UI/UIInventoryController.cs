using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;
    public int inventorySize = 12;

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize); //pass inventorysize to the initalization method
    }

    private void Awake ()
    {
        inventoryUI.Hide();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                //disable movement, arrow keys reassigned to inspecting menu items
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
