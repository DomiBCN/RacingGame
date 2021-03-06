﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    Transform player;
    CheckpointManager checkManager;

    private void Awake()
    {
        //player = GameObject.Find("Car").transform;
        //checkManager = player.GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.transform.root.tag != "Player")
        //{
        //    return;
        //}
        //print(other.transform.root.name);
        checkManager = other.transform.root.GetComponent<CheckpointManager>();

        if (transform == checkManager.checkpoints[checkManager.nextCheckpoint].transform)
        {
            if (checkManager.checkpoints.Count > checkManager.nextCheckpoint + 1)
            {
                checkManager.nextCheckpoint++;
                if (checkManager.nextCheckpoint == 1)
                {
                    checkManager.currentLap++;
                }
            }
            else
            {
                checkManager.nextCheckpoint = 0;
            }
            checkManager.UpdateSeconds(10);
            if (other.transform.root.tag == "Player")
            {
                UpdateCheckpoint(transform, false);
                UpdateCheckpoint(checkManager.checkpoints[checkManager.nextCheckpoint].transform, true);
            }
        }
    }

    void UpdateCheckpoint(Transform checkTransform, bool status)
    {
        //if (status)
        //{
        //    checkTransform.GetComponent<MeshCollider>().enabled = status;
        //}
        checkTransform.GetComponent<MeshRenderer>().enabled = status;
        checkTransform.GetComponentInChildren<SpriteRenderer>().enabled = status;
    }
}
