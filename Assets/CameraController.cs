using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
public class CameraController : MonoBehaviour {
    public Ball ball;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        offset = this.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = ball.transform.position + offset;
	}
}
