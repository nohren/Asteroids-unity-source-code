using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //laser lifeSpan
    const float lifeSpan = 0.5f;
    Timer deathTimer;
    

    private void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = lifeSpan;
        deathTimer.Run(); 
    }

    private void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }


    //laser vector and magnitude    
    public void ApplyForce(Vector2 laserDirection)
    {
        const float forceMagnitude = 100f;
        GetComponent<Rigidbody2D>().AddForce(laserDirection * forceMagnitude, ForceMode2D.Impulse);
        
    }
   
}
