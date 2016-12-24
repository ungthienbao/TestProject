using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {
    private const int bufferFrame = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrame];
    private Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}

    private void Record() {
        int frame = Time.frameCount % bufferFrame;
        float time = Time.time;
        print("Writing frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
    private void PlayBack() {
        rigid.isKinematic = true;
        int frame = Time.frameCount % bufferFrame;
        print("Reading frame: " + frame);
        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;
    }
    // Update is called once per frame
    void Update () {
        Record();
        PlayBack();
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
