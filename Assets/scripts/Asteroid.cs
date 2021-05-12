//using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
//using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    
    
    //sprite fields
    [SerializeField]
    Sprite asteroidBig;
    [SerializeField]
    Sprite asteroidMedium;
    [SerializeField]
    Sprite asteroidSmall;
    [SerializeField]
    GameObject explosion;

    CircleCollider2D collider;

  


    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>();
        

    }

  //create a public Initialize method with two parameters (direction and startLocation)
  public void Initialize(Direction direction)
    {
        
        //constant asteroid impulse force
        const float minImpulseForce = 1f;
        const float maxImpulseForce = 3f;

       
        

        //set direction based on parameter
        if (direction == Direction.Up)
        {
            float angle = (Random.Range(105 * Mathf.Deg2Rad, 75 * Mathf.Deg2Rad));
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            //set position at bottom of screen
            Vector3 startPosition = transform.position;
            startPosition.x = 0;
            startPosition.y = ScreenUtils.ScreenBottom;
            transform.position = startPosition;

            //move asteroid
            float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else if (direction == Direction.Down)
        {
            float angle = (Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad));
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            //set position at top of screen
            Vector3 startPosition = transform.position;
            startPosition.x = 0;
            startPosition.y = ScreenUtils.ScreenTop;
            transform.position = startPosition;

            //move asteroid
            float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else if (direction == Direction.Left)
        {
            float angle = (Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad));
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            //set position at right of screen
            Vector3 startPosition = transform.position;
            startPosition.x = ScreenUtils.ScreenRight;
            startPosition.y = 0;
            transform.position = startPosition;

            //move asteroid
            float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else if (direction == Direction.Right)
        {
            float angle = (Random.Range(345 * Mathf.Deg2Rad, 375 * Mathf.Deg2Rad));
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            //set position at left of screen
            Vector3 startPosition = transform.position;
            startPosition.x = ScreenUtils.ScreenLeft;
            startPosition.y = 0;
            transform.position = startPosition;

            //move asteroid
            float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }

        //choose random Asteroid
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidBig;
            gameObject.GetComponent<CircleCollider2D>().radius *= 3.75f;
        }
        else if (spriteNumber == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidMedium;
            gameObject.GetComponent<CircleCollider2D>().radius *= 2f;
            
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSmall;
            
        }
    }

    //written first in psuedocode, then translated
    //upon asteroid collision with laser and only laser, destroy asteroid
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Laser")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (transform.localScale.y < 1f)
            {
                Destroy(gameObject);
            }
            else
            {
                //instantiate two gameObject at 1/2 the size
                GameObject halfAsteroid1 = Instantiate(gameObject);
                halfAsteroid1.transform.position = transform.position;
                //cut asteroid in half
                Vector3 vect = transform.localScale;
                vect.x *= 0.5f;
                vect.y *= 0.5f;
                halfAsteroid1.transform.localScale = vect;
                //anytime an object refers to a component or script/class
                //it must get that component
                halfAsteroid1.GetComponent<Asteroid>().StartMoving();

                GameObject halfAsteroid2 = Instantiate(gameObject);
                halfAsteroid2.transform.position = transform.position;
                //cut asteroid in half
                halfAsteroid2.transform.localScale = vect;
                halfAsteroid2.GetComponent<Asteroid>().StartMoving();

                Destroy(gameObject);

            }
           
            
        }

    }
    public void StartMoving()
    {
        const float minImpulseForce = 1f;
        const float maxImpulseForce = 3f;
        float angle = (Random.Range(0f, 2f * Mathf.PI));
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //move asteroid
        float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }
}
