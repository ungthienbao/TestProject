using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour {
    private GameObject player;
    //private Vector3 offset;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //offset = this.transform.position - ball.transform.position;
	}
    void LateUpdate() {
        transform.LookAt(player.transform);
    }
}
