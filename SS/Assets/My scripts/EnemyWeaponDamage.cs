using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int WeaponDamage = 1;
    private bool HitActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (HitActive == false)
            {
                HitActive = true;
                SaveScript.PlayerHealth -= WeaponDamage;
                SaveScript.HealthChanged = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HitActive == true)
            {
                HitActive = false;
            }
        }
    }


}
