﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {
    private GameObject player;
    public float panSpeed = 10f;
    private Vector3 armRotation;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        armRotation.y += Input.GetAxis("RHorizontal") * panSpeed;
        armRotation.x += Input.GetAxis("RVertical") * panSpeed;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);

	}
}
