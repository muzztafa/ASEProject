using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    bool InventoryActive = false;
    //Apple
    [SerializeField] GameObject appleImage;
    [SerializeField] GameObject appleButton;
    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject appleButton1;
    [SerializeField] GameObject appleImage2;
    [SerializeField] GameObject appleButton2;
    [SerializeField] GameObject appleImage3;
    [SerializeField] GameObject appleButton3;
    [SerializeField] GameObject appleImage4;
    [SerializeField] GameObject appleButton4;
    [SerializeField] GameObject appleImage5;
    [SerializeField] GameObject appleButton5;
    //weapons
    [SerializeField] GameObject knifeImage;
    [SerializeField] GameObject knifeButton;
    [SerializeField] GameObject axeImage;
    [SerializeField] GameObject axeButton;
    [SerializeField] GameObject gunImage;
    [SerializeField] GameObject gunButton;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;
        Cursor.visible = false;
        appleImage.gameObject.SetActive(false);
        appleButton.gameObject.SetActive(false);
        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);
        appleImage2.gameObject.SetActive(false);
        appleButton2.gameObject.SetActive(false);
        appleImage3.gameObject.SetActive(false);
        appleButton3.gameObject.SetActive(false);
        appleImage4.gameObject.SetActive(false);
        appleButton4.gameObject.SetActive(false);
        appleImage5.gameObject.SetActive(false);
        appleButton5.gameObject.SetActive(false);
        knifeImage.gameObject.SetActive(false);
        knifeButton.gameObject.SetActive(false);
        axeButton.gameObject.SetActive(false);
        axeImage.gameObject.SetActive(false);
        gunImage.gameObject.SetActive(false);
        gunButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive==false)
            {
                InventoryMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else if(InventoryActive==true)
            {
                InventoryMenu.gameObject.SetActive(false);
                InventoryActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
        checkInventory();
        checkWeapons();
    }

    void checkInventory()
    {
        if(SaveScript.Apples == 1)
        {
            appleImage.gameObject.SetActive(true);
            appleButton.gameObject.SetActive(true);
        }
        if (SaveScript.Apples == 2)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(true);
        }
        if (SaveScript.Apples == 3)
        {
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(true);
        }
        if (SaveScript.Apples == 4)
        {
            appleImage3.gameObject.SetActive(true);
            appleButton3.gameObject.SetActive(true);
        }
        if (SaveScript.Apples == 5)
        {
            appleImage4.gameObject.SetActive(true);
            appleButton4.gameObject.SetActive(true);
        }
        if (SaveScript.Apples == 6)
        {
            appleImage5.gameObject.SetActive(true);
            appleButton5.gameObject.SetActive(true);
        }
    }
    void checkWeapons()
    {
        if(SaveScript.knife == true)
        {
            knifeImage.gameObject.SetActive(true);
            knifeButton.gameObject.SetActive(true);
        }else if(SaveScript.knife == false)
        {
            knifeImage.gameObject.SetActive(false);
            knifeButton.gameObject.SetActive(false);
        }
        if (SaveScript.axe == true)
        {
            axeImage.gameObject.SetActive(true);
            axeButton.gameObject.SetActive(true);
        }
        else if (SaveScript.axe == false)
        {
            axeImage.gameObject.SetActive(false);
            axeButton.gameObject.SetActive(false);
        }
        if (SaveScript.gun == true)
        {
            gunImage.gameObject.SetActive(true);
            gunButton.gameObject.SetActive(true);
        }
        else if (SaveScript.gun == false)
        {
            gunImage.gameObject.SetActive(false);
            gunButton.gameObject.SetActive(false);
        }
    }
    public void updateHealth()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.HealthChanged = true;
        SaveScript.Apples -= 1;
        appleImage.gameObject.SetActive(false);
        appleButton.gameObject.SetActive(false);
    }
}
