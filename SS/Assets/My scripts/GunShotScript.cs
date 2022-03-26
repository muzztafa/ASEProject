using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotScript : MonoBehaviour
{

    RaycastHit hit;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.HaveGun == true)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(Physics.Raycast(transform.position, transform.forward, out hit, 3000))
                {
                    if(hit.transform.Find("Body"))
                    {
                        hit.transform.gameObject.GetComponentInChildren<EnemyDamage>().EnemyHealth -= Random.Range(30,101);
                        hit.transform.gameObject.GetComponent<Animator>().SetTrigger("BigReact");
                    }
                }
            }
        }
        
    }
}
