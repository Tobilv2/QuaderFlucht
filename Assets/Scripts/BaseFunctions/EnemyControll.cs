using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyControll : MonoBehaviour
{
    public int force;
    private GameObject o;
    private NavMeshAgent navMeshAgent;
    private GameObject gameObjectToFollow;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameObjectToFollow = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = gameObjectToFollow.transform.position;
        navMeshAgent.SetDestination(playerPos);
    }

    
    
//    private void OnCollisionEnter(Collision other)
//    {
//        if (other.transform.CompareTag("Player"))
//        {
//            Vector3 direction = other.transform.position - transform.position;
//            //push player back
//          //  other.transform.GetComponent<Rigidbody>().AddForce(force * direction);
//        }
//    }

}