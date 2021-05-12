using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //Spawn asteroids
    [SerializeField]
    GameObject prefabAsteroid;

    //start hyperdrive trouble clip, then millenum falcon engine
  

    void Start()
    {
        
        AudioManager.StopClip();
        AudioManager.Play(AudioClipName.FalconFlyBy);
        //instantiate the asteroid and then access the asteroids script to initialize()
        GameObject asteroid1 = Instantiate(prefabAsteroid) as GameObject;
        asteroid1.GetComponent<Asteroid>().Initialize(Direction.Left);

        GameObject asteroid2 = Instantiate(prefabAsteroid) as GameObject;
        asteroid2.GetComponent<Asteroid>().Initialize(Direction.Up);

        GameObject asteroid3 = Instantiate(prefabAsteroid) as GameObject;
        asteroid3.GetComponent<Asteroid>().Initialize(Direction.Right);

        GameObject asteroid4 = Instantiate(prefabAsteroid) as GameObject;
        asteroid4.GetComponent<Asteroid>().Initialize(Direction.Down);
    }

}
