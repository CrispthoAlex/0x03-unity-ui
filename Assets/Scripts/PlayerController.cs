using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scenes
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Define the speed at which the object moves.
    // Modified by the user.
    public float speed;
    // Used for Coin object
    private int score = 0;
    // Used for Player health
    public int health = 5;

    // Value of the Scoretext
    public Text scoreText;

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
        rb = GetComponent<Rigidbody> ();
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
    // Reload the scene when Health player is over
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            // Loads the Scene by its name or index in Build Settings
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    // Function to control Player game properties
    void OnTriggerEnter(Collider other)
    {
        // Used to match the Object wit the tag Pickup
        if (other.CompareTag("Pickup"))
        {
            // Increase score when touch the coin
            score++;
            // Print in Console the score
            // Debug.Log($"Score: {score}");
            // Update Score text
            SetScoreText();
            // Destroy after touch the coin.
            Destroy(other.gameObject);
        }
        // Player health is affected
        if (other.CompareTag("Trap"))
        {
            // decrement the value of health when the Player touches
            // an object tagged Trap
            health--;
            // Print in Console the health
            Debug.Log($"Health: {health}");
        }
        // Player wins!!!
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
