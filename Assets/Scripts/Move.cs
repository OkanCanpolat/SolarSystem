using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class provide the planet to rotate around itself
public class Move : MonoBehaviour
{
    public int rotateSpeed;
    public Transform rotateAxis = null; // This axis will be planet's y axis

    void Update()
    {
        // Update method will provide planet to rotate around itself
        transform.RotateAround(rotateAxis.transform.position,
            rotateAxis.transform.up, rotateSpeed * Time.deltaTime);
    }
}
