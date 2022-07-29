using UnityEngine;

//This scriptable object stores planet's curves data

[CreateAssetMenu(fileName ="PlanetInfo")]
public class PlanetPositionInfoSO : ScriptableObject
{
   [SerializeField] Transform[] curves;

    public Transform[] _curves
    {
        get
        {
            return curves;
        }
    }
}
