using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnacleBehaviour : MonoBehaviour
{
//Attach this script to a GameObject with a Rigidbody. Press the up and down keys to move the Rigidbody up and down.
//Press the space key to freeze all positions and rotations.


    Rigidbody m_Rigidbody;
    Vector3 m_YAxis;
    public float xz_scaleFactor_min;
    public float xz_scaleFactor_max;
    public float y_scaleFactor_min;
    public float y_scaleFactor_max;
    Vector3 positionOnGround;
    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set up vector for moving the Rigidbody in the y axis
        m_YAxis = new Vector3(0, 5, 0);


        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground") 
        {
            //Freeze all positions and rotations
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            positionOnGround.x = transform.position.x;
            positionOnGround.y = transform.position.y;
            positionOnGround.z = transform.position.z;
        }
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Ground") 
        {
            transform.localScale += new Vector3(Random.Range(xz_scaleFactor_min,xz_scaleFactor_max), Random.Range(y_scaleFactor_min,y_scaleFactor_max), Random.Range(xz_scaleFactor_min,xz_scaleFactor_max));
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(positionOnGround.x, positionOnGround.y, positionOnGround.z);
    }
    
}
