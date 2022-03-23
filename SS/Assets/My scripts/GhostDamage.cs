using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    [SerializeField] int GhostHealth = 100;
    private AudioSource MyPlayer;
    private bool HasDied = false;
    private Animator Anim;
    [SerializeField] GameObject GhostObject;
    [SerializeField] GameObject BloodSplatKnife;
    [SerializeField] GameObject BloodSplatAxe;

    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
        Anim = GetComponentInParent<Animator>();
        BloodSplatKnife.gameObject.SetActive(false);
        BloodSplatAxe.gameObject.SetActive(false);
    }

    
    void Update()
    {
        //controlling death of Ghost
        if (GhostHealth <= 0)
        {
            if(HasDied == false)
            {
                Anim.SetTrigger("Death");
                Anim.SetBool("IsDead", true);
                HasDied = true;
                Destroy(GhostObject, 25f);
                SaveScript.reward += 50;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Damaging Health of Ghost
        if (other.gameObject.CompareTag("PKnife"))
        {
            GhostHealth -= 10;
            MyPlayer.Play();

            if (HasDied == false)
            {
                BloodSplatKnife.gameObject.SetActive(true);
            }
        }

        if (other.gameObject.CompareTag("PAxe"))
        {
            GhostHealth -= 20;
            MyPlayer.Play();
            if (HasDied == false)
            {
                BloodSplatAxe.gameObject.SetActive(true);
            }
        }

    }
}
