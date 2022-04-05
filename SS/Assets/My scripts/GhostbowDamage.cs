using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostbowDamage : MonoBehaviour
{

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ghost")){
            Debug.Log("GhostVisible");
            Destroy(other.gameObject);
        }
    }
// [SerializeField] int WeaponDamage = 1;
//     private bool HitActive = false;

//     private void OnTriggerEnter(Collider other)
//     {
//         if(other.gameObject.CompareTag("Ghost"))
//         {
//             if (HitActive == false)
//             {
//                 HitActive = true;
//                 //SaveScript.GhostHealth -= WeaponDamage;
//                 //SaveScript.HealthChanged = true;
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.gameObject.CompareTag("Ghost"))
//         {
//             if (HitActive == true)
//             {
//                 HitActive = false;
//             }
//         }
//     }



}
