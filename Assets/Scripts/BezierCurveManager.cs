using UnityEngine;

//This script uses cubic bezier curve formula to provide elliptical planet orbit points
public class BezierCurveManager : MonoBehaviour
{
    public static BezierCurveManager sharedInstance = null;

    private void Awake()
    {
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    public Vector3 GetBezierCurve(float t , 
        Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
       return Mathf.Pow(1 - t, 3) * p0 +
            3 * Mathf.Pow(1 - t, 2) * t * p1 +
            3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
            Mathf.Pow(t, 3) * p3;
    }
}
