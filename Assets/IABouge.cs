using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABouge : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;
    [SerializeField] float sightRange;
    Vector3 position;
    Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if(!playerInSight){
            position = transform.position;
            Patrol();
        } else if(playerInSight){
            Found(position);
        }
    }

    void Found(Vector3 position){
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            animator.SetTrigger("Idle");
            agent.SetDestination(position);
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleAigle")){
            animator.SetTrigger("Idle");
            agent.SetDestination(position);
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idleJitter")){
            animator.SetTrigger("Idle");
            agent.SetDestination(position);
        }
    }

    void Patrol(){
    if(!walkPointSet){
        SearchForDest();
    }

    if(walkPointSet){
        agent.SetDestination(destPoint);
    } 

    if(Vector3.Distance(transform.position, destPoint) < 2){
        walkPointSet = false;
    }
}


    void SearchForDest(){
    Vector3 randomDirection = Random.insideUnitSphere * range;
    randomDirection += transform.position;
    NavMeshHit hit;
    NavMesh.SamplePosition(randomDirection, out hit, range, 1);
    destPoint = hit.position;
    walkPointSet = true;
}


}
