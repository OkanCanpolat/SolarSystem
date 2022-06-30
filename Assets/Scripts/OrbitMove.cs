using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class provide planet to rotate around the Sun and determine full circle
public class OrbitMove : MonoBehaviour
{
    public int orbitalSpeed;
    public Transform orbitalAxis = null;
    public string planetName;
    private float rotateAngle;
    
    
    void Update()
    {
        RotateAroundSun();
        ChechkRotate();
    }

    void RotateAroundSun()
    {
        //Rotate the object around the Sun
        transform.RotateAround(orbitalAxis.transform.position,
            orbitalAxis.transform.up, orbitalSpeed * Time.deltaTime);
        //Calculate the angle the planet rotates
        rotateAngle += orbitalSpeed * Time.deltaTime;
    }

    void ChechkRotate()
    {
        //If the planet made a full circle reset rotateAngle and print to screen
        if(rotateAngle >= 360)
        {
            rotateAngle = 0;
            Debug.Log(planetName + " made a full circle");
        }
    }

}
