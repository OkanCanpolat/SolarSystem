using System.Collections.Generic;
using UnityEngine;

//This script activates the explosion effect when asteroid collide with a plane
public class AsteroidEffects : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] List<GameObject> trails; //This variable is used to keep the asteroid's tail alive when the asteroid is destroyed to provide a more realistic effect 
    private void OnCollisionEnter(Collision collision)
    {
        // identify collision point and create an asteroid based on that point 
        ContactPoint cont = collision.GetContact(0);

        Quaternion rot = Quaternion.FromToRotation(Vector3.up,
            cont.normal);
        Vector3 pos = cont.point;

        if(explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab,
                pos, rot);

            Destroy(explosion, 2);
        }

        //if asteroid has trails seperate the trails from asteroid before asteroid destroyed
        if(trails.Count > 0)
        {
            for(int i = 0; i < trails.Count; i++)
            {
                trails[i].transform.parent = null;
            }
        }

        //destroy asteroid
        Destroy(gameObject);
    }
}
