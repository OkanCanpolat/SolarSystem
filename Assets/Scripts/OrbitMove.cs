using System.Collections;
using UnityEngine;

// This class provide planet to rotate around the Sun and determine full circle
public class OrbitMove : MonoBehaviour
{
    [Range(0.01f, 1f)]
    [SerializeField] float orbitalSpeed;
    [SerializeField] string planetName;

    //a reference to scriptable object
    [SerializeField] PlanetPositionInfoSO planetInfo;
    
    private int currentCurve = 0;

    private void Start()
    {
        StartCoroutine(RotateAroundSun());
    }
    

    IEnumerator RotateAroundSun()
    {

        Vector3 destination = transform.position;
        float t = 0f;

        while (t < 1)
        {
            t += orbitalSpeed * Time.deltaTime;
            destination = BezierCurveManager.
                sharedInstance.GetBezierCurve(t,
                   planetInfo._curves[currentCurve].GetChild(0).position,
                   planetInfo._curves[currentCurve].GetChild(1).position,
                   planetInfo._curves[currentCurve].GetChild(2).position,
                   planetInfo._curves[currentCurve].GetChild(3).position);

            transform.position = destination;

            yield return new WaitForEndOfFrame();
        }

        //After completing one of the curves, switch to the next
        currentCurve++;

        //if each curve is completed start the loop again
        if(currentCurve == planetInfo._curves.Length)
        {
            currentCurve = 0;
            Debug.Log(planetName + " made a full circle");
        }

        StartCoroutine(RotateAroundSun());
        yield break;
    }

}
