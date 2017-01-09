using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
    private bool isPaused = false;
    public bool recording = true;
    private float initFixedDeltaTime;
    void Start() {
        initFixedDeltaTime = Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        }
        else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && !isPaused) {
            isPaused = true;
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused) {
            isPaused = false;
            ResumGame();
        }
    }

    void Pause() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumGame() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initFixedDeltaTime ;
    }
    void OnApplication(bool pauseStatus) {
        isPaused = pauseStatus;
    }
}
