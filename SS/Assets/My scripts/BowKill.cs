using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowKill : MonoBehaviour
{
    [SerializeField] int WeaponDamage = 100;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ghost"))
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
