using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
    public WheelScript[] wheels;

    [Header("Car Specs")]
    public float wheelBase; // in meters
    public float rearTrack; // in meters
    public float turnRadius; // in meters

    [Header("Inputs")]
    public float steerInput;

    public float ackermannAngleLeft;
    public float ackermannAngleRight;

    void Update() {
        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0) { // is turning right
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        } else if (steerInput < 0) { // is turning left
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        } else {
            ackermannAngleLeft = 0;
            ackermannAngleRight = 0;
        }

        foreach(WheelScript w in wheels) {
            if (w.wheelFrontLeft) w.steerAngle = ackermannAngleLeft;
            if (w.wheelFrontRight) w.steerAngle = ackermannAngleRight;
        }
    }
}
