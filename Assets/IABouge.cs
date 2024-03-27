using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABouge : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol(){
    if(!walkPointSet){
        SearchForDest();
    }

    if(walkPointSet){
        agent.SetDestination(destPoint);
        transform.rotation = Quaternion.Euler(90, 0, 0); // Fixer la rotation à 0,0,0
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
