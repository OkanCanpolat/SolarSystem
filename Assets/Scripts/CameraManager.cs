using System.Collections;
using UnityEngine;

//This script manages all camera movements
public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera upCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject origin;
    [SerializeField] private float cameraRotateSpeed;
    private bool isRotating = false;

    private void Start()
    {
        upCamera.enabled = false;
    }

    //change camera from up to main or vice versa
    public void ChangeCamera()
    {

        if (mainCamera.enabled == true)
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


    //if camera rotating then stop rotation if not start rotation
    public void CheckCameraSituation()
    {
        if (isRotating == true)
        {
            
            StopAllCoroutines();
            isRotating = false;
        }

        else
        {
            
            StartCoroutine(RotateMainCamera());
            isRotating = true;
        }
    }

    public IEnumerator RotateMainCamera()
    {
            mainCamera.transform.RotateAround(
          origin.transform.position,
          origin.transform.up,
          cameraRotateSpeed * Time.deltaTime);

        yield return new WaitForEndOfFrame();

        StartCoroutine(RotateMainCamera());

        yield break;
    }
}
