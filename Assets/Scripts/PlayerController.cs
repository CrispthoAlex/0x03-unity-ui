using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define the speed at which the object moves.
    // Modified by the user.
    public float speed;

    // Vector3 - Representation of 3D vectors and points.
    // Catch the x, y, z axis for translation and rotation movements.
    Vector3 translateObj;
    Vector3 rotateObj;
    
    // Reference to Rigidbody component
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Use GetComponent to access the component.
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the value of the X and Z input axis for movement.
        translateObj.x = Input.GetAxis("Horizontal");
        translateObj.z = Input.GetAxis("Vertical");
        // Apply force to move the assets
        rb.AddForce(translateObj * speed * Time.deltaTime) ; 
        
        // Invert the Axis => move in X rotate in Z
        rotateObj.x = Input.GetAxis("Vertical");
        rotateObj.z = Input.GetAxis("Horizontal");
        // Apply force to rotate the assets
        rb.transform.Rotate(rotateObj * speed * Time.deltaTime) ;
    }
    // Update is called once per frame. void Update() method to use later
}
