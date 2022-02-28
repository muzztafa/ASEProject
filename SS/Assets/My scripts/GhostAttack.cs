using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool isChecking = true;
    private int FailedChecks = 0;

    [SerializeField] Transform Player; //this is the FPS controller
    [SerializeField] Animator Anim; //this is the controller that handles our animations
    [SerializeField] GameObject Enemy; //this is the parasite
    [SerializeField] float MaxRange = 40f; //the range in which enemy can see our player
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float chaseSpeed = 8.5f;
    [SerializeField] float walkSpeed = 1.5f;
    [SerializeField] float attachDistance = 2.5f;
    [SerializeField] float attackRotateSpeed = 2.0f;
    [SerializeField] float checkTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //navmeshagent is the parent parasite
        Nav = GetComponentInParent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);

        if (DistanceToPlayer < MaxRange)
        {
            if (isChecking == true)
            {
                isChecking = false;

                //check whether the enemy can see our player in the navmesh
                blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);

                if (blocked == false)
                {
                    Debug.Log("Player VISIBLE");
                    RunToPlayer = true;
                }
                if (blocked == true)
                {
                    Debug.Log("NOT VISIBLE");
                    RunToPlayer = false;
                    Anim.SetInteger("State", 0);
                }

                //wait for a few seconds 
                StartCoroutine(TimedCheck());
            }
        }

        if (RunToPlayer == true)
        {
            //if enemy is far from player, run to player
            if (DistanceToPlayer > attachDistance)
            {
                Nav.isStopped = false;
                Anim.SetInteger("State", 1);
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                Nav.speed = chaseSpeed;
            }

            //if enemy is close to player, attack
            if (DistanceToPlayer < attachDistance)
            {
                Nav.isStopped = true;
               // Debug.Log("I am attacking");
                Anim.SetInteger("State", 2);
                Nav.acceleration = 180;
            }
        }
        else if (RunToPlayer == false)
        {
            Nav.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }
/*
        if (other.gameObject.CompareTag("Knife"))
        {
            Anim.SetTrigger("SmallReact");
        }
*/
    }
    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(checkTime);
        isChecking = true;
    }
}