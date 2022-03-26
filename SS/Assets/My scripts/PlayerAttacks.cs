
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    private Animator Anim;

    //to stop the spam of attacks we are limiting the attack with adding stamina
    private float AttackStamina;
    [SerializeField] float MaxAttackStamina = 10;
    [SerializeField] float AttackDrain = 2;
    [SerializeField] float AttackRefill = 1;
    [SerializeField] GameObject Crosshair;

    private AudioSource MyPlayer;
    [SerializeField] AudioClip GunShotSound;



    void Start()
    {
        Anim = GetComponent<Animator>();
        AttackStamina = MaxAttackStamina;
        Crosshair.gameObject.SetActive(false);
        MyPlayer = GetComponent<AudioSource>();
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

               if (SaveScript.HaveGun == true)
            {
            Crosshair.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    MyPlayer.clip = GunShotSound;
                    MyPlayer.Play();
                }

            }
            if(SaveScript.HaveGun == false)
            {
            Crosshair.gameObject.SetActive(false);
            }
        

        }
    }
}
