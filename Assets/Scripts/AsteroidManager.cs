using UnityEngine;

//This script checks the asteroid's move
public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager sharedInstance = null;

    [SerializeField] GameObject asteroidPrefab;

    //origin object variable is used to determine spawn point range
    [SerializeField] GameObject originObject;
    //Asteroid can be created at a distance of up to distanceFromOrigin distance from the origin except inside safeArea
    [SerializeField] float distanceFromOrigin;
    //Asteroid will not be created in the area as far as the safeArea distance from the origin.
    [SerializeField] float safeArea;
    //planets variable is used to determine the planet which the asteroid will move
    [SerializeField] GameObject[] planets;
    [SerializeField] float asteroidSpeed;

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

    //set a position that asteroid will spawn on
    public Vector3 SetRandomPosition()
    {
        float random = Random.Range(safeArea, distanceFromOrigin);
        Vector3 randomVector = new Vector3(random, random, random);
        Vector3 position = originObject.transform.position + 
            randomVector;

        return position;
    }

    //if user pressed Space create an asteroid
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject asteroid = Instantiate(asteroidPrefab, 
                SetRandomPosition(), Quaternion.identity);

            Force(asteroid);
        }
    }

    //set the planet that asteroid will move to
    public GameObject SetRandomPlanet()
    {
        int planetIndex = Random.Range(0, planets.Length);
        return planets[planetIndex];
    }

    //Add force to the asteroid
    public void Force(GameObject asteroid)
    {
        GameObject targetPlanet = SetRandomPlanet();
        Debug.Log("Destination   " + targetPlanet.name);
        Vector3 destination = targetPlanet.transform.position -
                    asteroid.transform.position;
        Vector3 normalizedVector = destination.normalized;
        Rigidbody rb = asteroid.GetComponent<Rigidbody>();
        rb.AddForce(normalizedVector * asteroidSpeed);
    }
}
