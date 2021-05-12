using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;

public class Ship : MonoBehaviour
{
    //update win the game flag support 
    public static bool gameWon = false;

    //populate HUD for timer stop function
    [SerializeField]
    GameObject hudd;

    //place laser gun on ship
    [SerializeField]
    GameObject prefabLaser;

    [SerializeField]
    GameObject explosion;

    ////declare field to hold rigidbody2d
    Rigidbody2D rb;

  

    //loading the class and field to prep for adding the script in update
    
        
    //constant of thrust... how fast does it move
    const float ThrustForce = 13;

    //constant of rotation... how fast does it rotate
    const float RotateDegreesPerSecond = 250;

    //store the default vector (1,0) 
    Vector2 thrustDirection = Vector2.right;

    //store rotation amount for laser
    float rotationAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameWon = false;
      
    }

    

    //Use FixedUpdate() for physics engine simulation
    void FixedUpdate()
    {
        //if space bar input, activate thruster
        if (Input.GetAxis("Thrust") != 0)
        {
            //propel object forward
            rb.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
            
        }
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
        //calculate rotation amount and apply rotation
        float rotationInput = Input.GetAxis("Rotate");
        rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        if (rotationInput < 0)
        {
           rotationAmount *= -1;
           transform.Rotate(Vector3.forward, rotationAmount);
           float degreeZ = transform.rotation.eulerAngles.z;
           float radianZ = degreeZ * Mathf.Deg2Rad;
           thrustDirection.x = Mathf.Cos(radianZ);
           thrustDirection.y = Mathf.Sin(radianZ);
            


        }
        if (rotationInput > 0)
        {
           transform.Rotate(Vector3.forward, rotationAmount);
           float degreeZ = transform.rotation.eulerAngles.z;
           float radianZ = degreeZ * Mathf.Deg2Rad;
           thrustDirection.x = Mathf.Cos(radianZ);
           thrustDirection.y = Mathf.Sin(radianZ);
           

        }

        //when left control is pressed, instantiate and fire laser gun
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //instance of an object, the lazeerrrrr at the ships transform
            GameObject laser = Instantiate(prefabLaser) as GameObject;
            //laser component attached to laser gameObject, 
            //ApplyForce method(thrustDirection)
            laser.GetComponent<Laser>().ApplyForce(thrustDirection);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            AudioManager.Play(AudioClipName.PlayerShot);
            


            


        }

        //if no asteroids around stop clock
        if (!GameObject.FindGameObjectWithTag("Asteroid") && !gameWon)
        {
            gameWon = true;
            AudioManager.Play(AudioClipName.R2happy);
            AudioManager.Play(AudioClipName.Lightspeed);
            HUD.StopGameTimer();
            MainMenu.themeSong = false;
            MenuManager.GotoMenu(MenuName.WinGame);
            Destroy(gameObject);
           
        }
        
     
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
       
        HUD.StopGameTimer();
        AudioManager.Play(AudioClipName.PlayerDeath);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        MainMenu.themeSong = false;
        MenuManager.GotoMenu(MenuName.ShipDestroyed);
        
    }
}
