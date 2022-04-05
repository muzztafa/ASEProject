using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    bool InventoryActive = false;
    private AudioSource MyPlayer;
    //[SerializeField] AudioClip WeaponChange;

    [SerializeField] AudioClip GunShot;
    [SerializeField] AudioClip ArrowShot;


    [SerializeField] GameObject PlayerArms;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject CrossBow;
    [SerializeField] Animator Anim;
    [SerializeField] GameObject Gunlogo;
    [SerializeField] GameObject BulletAmt;
    [SerializeField] GameObject BowUI;
    [SerializeField] GameObject BowAmt;

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
    [SerializeField] GameObject crossbowImage;
    [SerializeField] GameObject crossbowButton;


    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        Gunlogo.gameObject.SetActive(false);
        BulletAmt.gameObject.SetActive(false);
        BowUI.gameObject.SetActive(false);
        BowAmt.gameObject.SetActive(false);

        InventoryActive = false;
        Cursor.visible = false;
        MyPlayer = GetComponent<AudioSource>();


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
        crossbowImage.gameObject.SetActive(false);
        crossbowButton.gameObject.SetActive(false);
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
                SaveScript.HaveKnife = false;
                SaveScript.HaveAxe = false;
                SaveScript.HaveCrossBow = false;
                SaveScript.HaveGun = false;
                Gunlogo.gameObject.SetActive(false);
                BulletAmt.gameObject.SetActive(false);
                BowUI.gameObject.SetActive(false);
                BowAmt.gameObject.SetActive(false);
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

    public void HealthUpdate()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.HealthChanged = true;

        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);
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
        // if (SaveScript.reward > 50)
        // {
            SaveScript.crossbow = true;
            crossbowImage.gameObject.SetActive(true);
            crossbowButton.gameObject.SetActive(true);
        // }
        // else
        // {
        //     SaveScript.crossbow = false;
        //     crossbowImage.gameObject.SetActive(false);
        //     crossbowButton.gameObject.SetActive(false);
        // }
    }
    public void updateHealth()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.HealthChanged = true;
        SaveScript.Apples -= 1;
        appleImage.gameObject.SetActive(false);
        appleButton.gameObject.SetActive(false);
    }

	public void AssignKnife()
    {
        PlayerArms.gameObject.SetActive(true);
        Knife.gameObject.SetActive(true);
        Anim.SetBool("Melee", true);
        Gun.gameObject.SetActive(false);
        Axe.gameObject.SetActive(false);
        CrossBow.gameObject.SetActive(false);

        //MyPlayer.clip = WeaponChange;
        //MyPlayer.Play();
        SaveScript.HaveKnife = true;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = false;
        SaveScript.HaveCrossBow = false;
    }

    public void AssignAxe()
    {
        PlayerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(true);
        Anim.SetBool("Melee", true);
        Gun.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        CrossBow.gameObject.SetActive(false);
        //MyPlayer.clip = WeaponChange;
        //MyPlayer.Play();
         SaveScript.HaveKnife = false;
        SaveScript.HaveAxe = true;
       SaveScript.HaveGun = false;
       SaveScript.HaveCrossBow = false;
    }

    public void AssignGun()
    {
        PlayerArms.gameObject.SetActive(true);
        Gun.gameObject.SetActive(true);
        Anim.SetBool("Melee", true);
        Axe.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        CrossBow.gameObject.SetActive(false);
        
        // MyPlayer.clip = GunShot;
        // MyPlayer.Play();
        
        SaveScript.HaveGun = true;
       SaveScript.HaveCrossBow = false;
       SaveScript.HaveKnife = false;
        SaveScript.HaveAxe = false;

        Gunlogo.gameObject.SetActive(true);
        BulletAmt.gameObject.SetActive(true);
    }

 public void AssignCrossbow()
    {
        PlayerArms.gameObject.SetActive(true);
        CrossBow.gameObject.SetActive(true);
        Anim.SetBool("Melee", true);
        Axe.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        // MyPlayer.clip = ArrowShot;
        // MyPlayer.Play();
        SaveScript.HaveKnife = false;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = false;
        SaveScript.HaveCrossBow = true;
          BowUI.gameObject.SetActive(true);
                BowAmt.gameObject.SetActive(true);
    }


    public void WeaponsOff()
    {
        Axe.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        CrossBow.gameObject.SetActive(false);

    }

    // public void AmmoRefill(){
    //     SaveScript.BulletClips -= 1;
    //     SaveScript.Bullets += 12;
    //     if(SaveScript.Bullets > 12)
    //     {
    //         SaveScript.Bullets = 12;
    //     }
    // }
}
