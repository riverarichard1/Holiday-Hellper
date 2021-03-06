﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Light))]
public class LightDetect2 : MonoBehaviour
{

    //get the distance from the center of the light source to the center of the player 
    // Determine how much of the player is in the light
    //return a percentage 
    public float distance;
    public float percentVisible;
    public GameObject player;
    private SphereCollider sc;
    public float offsetY; //Used to bring the center of the light down closer to the ground

    public static event Action<float> PercentVisible;

    private void OnDisable()
    {
        percentVisible = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<Light>().enabled == true) {
            if (other.gameObject == player)
            {
                Vector3 newPoint = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                distance = Vector3.Distance(newPoint, player.transform.position);
                //distance = Vector3.Distance(transform.position, player.transform.position);
                //Debug.DrawRay(newPoint, player.transform.position - newPoint, Color.yellow);
                percentVisible = ((1 / distance) * 5f); //there's probably a better formula but this is what I came up with
                percentVisible = Mathf.Clamp(percentVisible, 0, 1f);
                sendNotif(percentVisible);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        percentVisible = 0;
        sendNotif(percentVisible);
    }

    //created a seperate method for sending notifcations so a notifcation can be sent whent he head light gets turned off
    public void sendNotif(float percent) {
        if (PercentVisible != null) { PercentVisible(percent); }
    }
}
