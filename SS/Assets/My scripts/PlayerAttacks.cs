
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    private Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(SaveScript.HaveAxe == true)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Anim.SetTrigger("AxeLMB");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Anim.SetTrigger("AxeRMB");
            }
        }

        if (SaveScript.HaveKnife == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Anim.SetTrigger("KnifeLMB");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Anim.SetTrigger("KnifeRMB");
            }
        }
    }
}
