using System.Collections;
using System.Collections.Generic;
using UnityEngine; //the namespace all the monobehavior content exists

/*
->Class Movement INHERITS MonoBehavior (MonoBehavior properties & methods are extended to Movement class)
->Classes should account for one type of behavior. Ex: a movement class should account for the movement
  of the object it is attached to. Collision class should account for the collision detection on an object
->Use encapsulation in code. (Getters & Setters, private attributes, etc.)
 */


public class Movement : MonoBehaviour 
{
    //Create serialized fields
    [SerializeField] float fltThrustSpeed = 1f;

    //Create object types
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); //Get rb attached to the same object the script is on
    }

    // Update is called once per frame
    void Update()
    {
        GetThrust(); //Get the input from the user
        GetRotation(); // Get the input from the user
    }

    //Method responsible for rotation of the player
    void GetRotation()
    {
        //If player is pressing both rotate buttons, don't rotate
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            Debug.Log("A and D button pressed (No rotation)");
        }
        //Otherwise, if they're pressing the ccw rotation button, rotate ccw
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A button pressed (Rotate ccw)");
        }
        //Otherwise, if they're pressing the cw rotation button, rotate cw
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D button pressed (Rotate cw)");
        }
    }
    
    //Method responsible for thrusting the player
    void GetThrust()
    {
        if (Input.GetKey(KeyCode.Space)) //Set KeyCode enumeration type to Space.
        {
            //F = ma, meaning a = F/m. Acceleration of object from force is dependent on amount of force & object's mass

            Vector3 forceAmount = Vector3.up * fltThrustSpeed * Time.deltaTime; //Vector3.up is the object's relative up direction
            playerRb.AddRelativeForce(forceAmount); //Add force to rb relative to its own direction (not world space)
        }
    }
}
