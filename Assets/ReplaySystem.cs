using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ReplaySystem : MonoBehaviour {
    private const int bufferFrame = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrame];
    private Rigidbody rigid;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}


    // Update is called once per frame
    void Update () {
        if (gameManager.recording) {
            Record();
        }
        else {
            PlayBack();
        }
    }
    private void Record() {
        //rigid.isKinematic = false;
        int frame = Time.frameCount % bufferFrame;
        float time = Time.time;
        print("Writing frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
    private void PlayBack() {
       // rigid.isKinematic = true;
        int frame = Time.frameCount % bufferFrame;
        //print("Reading frame: " + frame);
        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;
    }
}

/// <summary>
/// A structure for storing time, position, rotation 
/// </summary>
public struct MyKeyFrame {
    public float frameTime;
    public Vector3 pos;
    public Quaternion rot;
    public MyKeyFrame(float time, Vector3 pos, Quaternion rot) {
        this.frameTime = time;
        this.pos = pos;
        this.rot = rot;
    }  

}
