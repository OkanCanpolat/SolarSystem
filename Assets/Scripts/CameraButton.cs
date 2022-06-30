using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allow us to change the camera view
public class CameraButton : MonoBehaviour
{
    [SerializeField] private Camera upCamera;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        upCamera.enabled = false;
    }
    public void ChangeCamera()
    {
        
        if(mainCamera.enabled == true)
        {
            mainCamera.enabled = false;
            upCamera.enabled = true;
        }

        else
        {
            mainCamera.enabled = true;
            upCamera.enabled = false;
        }
    }
}
