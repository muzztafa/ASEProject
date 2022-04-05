
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
public class PlayerAttacks : MonoBehaviour
{

    private Animator Anim;

    //to stop the spam of attacks we are limiting the attack with adding stamina
    private float AttackStamina;
    [SerializeField] float MaxAttackStamina = 10;
    [SerializeField] float AttackDrain = 2;
    [SerializeField] float AttackRefill = 1;
    [SerializeField] GameObject Crosshair;
    [SerializeField] GameObject GunCrossHair;
    public GameObject arrowPrefab;
    private AudioSource MyPlayer;
    public Transform arrowLocation;
    public float shotPower = 500f;
    [SerializeField] AudioClip GunShotSound;
    [SerializeField] AudioClip ArrowShotSound;
    [SerializeField] Text BowAmt;
    Dictionary<string, Action> keywordAction = new Dictionary<string, Action>();
    KeywordRecognizer keywordRecognizer;
    void Start()
    {
        Anim = GetComponent<Animator>();
        AttackStamina = MaxAttackStamina;
        Crosshair.gameObject.SetActive(false);
        GunCrossHair.gameObject.SetActive(false);
        /*if (arrowLocation == null)
            arrowLocation = transform;*/
        keywordAction.Add("shoot", shoot) ;
        keywordAction.Add("Shooot", shoot);
        keywordAction.Add("Shot", shoot);
        keywordRecognizer = new KeywordRecognizer(keywordAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        MyPlayer = GetComponent<AudioSource>();
        keywordRecognizer.Start();
    }

             void OnKeywordsRecognized(PhraseRecognizedEventArgs Speech)
             {
                 Debug.Log("Keyword: " + Speech.text); 
                 keywordAction[Speech.text].Invoke();
             }
             
    //          private void OnTriggerEnter(Collider other){
    //     if(other.gameObject.CompareTag("Ghost"))
    //     {
    //         if (HitActive == false)
    //         {
    //             HitActive = true;
    //             SaveScript.PlayerHealth -= WeaponDamage;
    //             SaveScript.HealthChanged = true;
    //         }
    //     }
    // }
    void shoot()
    {
        //Debug.Log("HI");
            if (SaveScript.HaveMagicSword == true)
            {
                // Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
                // SaveScript.Arrows -= 1;
                // BowAmt.text = SaveScript.Arrows + "";
                Anim.SetTrigger("KnifeRMB");

            }
        
    }
    void Update()
    {
        
        if(AttackStamina < MaxAttackStamina)
        {
            AttackStamina += AttackRefill * Time.deltaTime;
        }

        //This will allow the stamina to not to go below 0
        if(AttackStamina <= 0.1)
        {
            AttackStamina = 0.1f;
        }
        //When ever the stamina will be greater than zero and player press mouse 0 or 1 it will drain some stamina
        if (AttackStamina > 3.0)
        {
            if (SaveScript.HaveAxe == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("AxeLMB");
                    AttackStamina -= AttackDrain;
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("AxeRMB");
                    AttackStamina -= AttackDrain;
                }
            }

            if (SaveScript.HaveKnife == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("KnifeLMB");
                    AttackStamina -= AttackDrain;
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("KnifeRMB");
                    AttackStamina -= AttackDrain;
                }

            }
            //            // 
            // if (SaveScript.HaveMagicSword == true)
            // {
            //     if (Input.GetKeyDown(KeyCode.Mouse0))
            //     {
            //         Anim.SetTrigger("KnifeRMB");
            //         AttackStamina -= AttackDrain;
            //     }
                
            // }
             

            if (SaveScript.HaveGun == true)
            {
                GunCrossHair.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetBool("ShootGun", true);
                    if(SaveScript.Bullets>0)
                    {
                    MyPlayer.clip = GunShotSound;
                    MyPlayer.Play();
                    }
                   
                }
                if(Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Anim.SetBool("ShootGun", false);
                    
                   
                }

               
                

            }
            if(SaveScript.HaveGun == false)
            {
                                GunCrossHair.gameObject.SetActive(false);

            }
            
             else
             {
             Crosshair.gameObject.SetActive(false);
             }


             if (SaveScript.HaveCrossBow == true)
             {
                Crosshair.gameObject.SetActive(true);

                /*if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if(SaveScript.Arrows > 0)
                     {
                     MyPlayer.clip = ArrowShotSound;
                     MyPlayer.Play();
                     }
                     
                   
                 }*/

             }
             else
             {
                Crosshair.gameObject.SetActive(false);
             }

            


        }
    }
}
