﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSpawner : MonoBehaviour {
    public List<Transform> patrolPoints = new List<Transform>();
    public GameObject patrolPrefab;
    public GameObject dadPrefab;
    public GameObject momPrefab;
    public GameObject dogPrefab;
    [SpaceAttribute]
    public int patrolAmount;
    public int dadAmount;
    public int momAmount;
    public int dogAmount;
    public bool wanderAll;
    //public float distanceAmount;

    void Start () {
        createPatrol();
        createDad();
        createMom();
        createDog();
	}
	
    void createPatrol() {
        for (int i = 0; i < patrolAmount; i++) {
            Transform spawnPos = patrolPoints[Random.Range(0, patrolPoints.Count)];
            //print(spawnPos);
            Quaternion rotation = transform.rotation;
            //instantiate patrol prefab
            GameObject patrol = Instantiate(patrolPrefab, spawnPos.position, rotation,transform);
            patrol.GetComponent<Patrol>().patrolPoints[0] = patrolPoints[Random.Range(0, patrolPoints.Count)];
           
            patrol.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];

            while (patrol.GetComponent<Patrol>().patrolPoints[0] == patrol.GetComponent<Patrol>().patrolPoints[1]) {
                patrol.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            }
            if (wanderAll) { patrol.GetComponent<Patrol>().wander = true; }
        }
    }

    void createDad() {
        for (int i = 0; i < dadAmount; i++)
        {
            Transform spawnPos = patrolPoints[Random.Range(0, patrolPoints.Count)];
            Quaternion rotation = transform.rotation;
            //instantiate decoy prefab
            GameObject parent = Instantiate(dadPrefab, spawnPos.position, rotation,transform);
            parent.GetComponent<Patrol>().patrolPoints[0] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            parent.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            while (parent.GetComponent<Patrol>().patrolPoints[0] == parent.GetComponent<Patrol>().patrolPoints[1])
            {
                parent.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            }
            if (wanderAll) { parent.GetComponent<Patrol>().wander = true; }
        }
    }

    void createMom()
    {
        for (int i = 0; i < momAmount; i++)
        {
            Transform spawnPos = patrolPoints[Random.Range(0, patrolPoints.Count)];
            Quaternion rotation = transform.rotation;
            //instantiate decoy prefab
            GameObject parent = Instantiate(momPrefab, spawnPos.position, rotation, transform);
            parent.GetComponent<Patrol>().patrolPoints[0] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            parent.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            while (parent.GetComponent<Patrol>().patrolPoints[0] == parent.GetComponent<Patrol>().patrolPoints[1])
            {
                parent.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            }
            if (wanderAll) { parent.GetComponent<Patrol>().wander = true; }
        }
    }

    void createDog() {
        for (int i = 0; i < dogAmount; i++)
        {
            Transform spawnPos = patrolPoints[Random.Range(0, patrolPoints.Count)];
            Quaternion rotation = transform.rotation;
            //instantiate decoy prefab
            GameObject dog = Instantiate(dogPrefab, spawnPos.position, rotation,transform);
            dog.GetComponent<Patrol>().patrolPoints[0] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            dog.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            while (dog.GetComponent<Patrol>().patrolPoints[0] == dog.GetComponent<Patrol>().patrolPoints[1])
            {
                dog.GetComponent<Patrol>().patrolPoints[1] = patrolPoints[Random.Range(0, patrolPoints.Count)];
            }
        }
    }
}
