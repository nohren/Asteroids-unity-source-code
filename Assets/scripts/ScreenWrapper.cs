using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    //declare field to hold rigidbody2d
    Rigidbody2D rb;

    //field to store radius of circle collider
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        //assign the component object to a variable rb
        rb = GetComponent<Rigidbody2D>();

        //radius = GetComponent<CircleCollider2D>().radius;
    }

    void OnBecameInvisible()
    {
        //on leaving the scene, ship reappears at the opposite transform coordinates

        //calculate difference in x and y values in order to determine if ship is at a corner
        float cornerPosition = ((Mathf.Abs(transform.position.x) - Mathf.Abs(transform.position.y)));
        //print(cornerPosition);

        if (transform.position.x > ScreenUtils.ScreenRight)
        {
            //if at a corner, *-1 x and *-1 y to keep slope
            if (cornerPosition <= 10 && cornerPosition > 5.5)
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                pos.y *= -1;
                transform.position = pos;
            }
            // only *-1 x to keep slope
            else
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                transform.position = pos;
            }

        }
        else if (transform.position.x < ScreenUtils.ScreenLeft)
        {
            if (cornerPosition <= 10 && cornerPosition > 5.5)
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                pos.y *= -1;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                transform.position = pos;
            }

        }
        else if (transform.position.y > ScreenUtils.ScreenTop)
        {
            if (cornerPosition <= 10 && cornerPosition > 5.5)
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                pos.y *= -1;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.y *= -1;
                transform.position = pos;
            }

        }
        else if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            if (cornerPosition <= 10 && cornerPosition > 5.5)
            {
                Vector2 pos = transform.position;
                pos.x *= -1;
                pos.y *= -1;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.y *= -1;
                transform.position = pos;
            }
        }

    }

}