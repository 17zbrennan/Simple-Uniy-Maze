//Zachary Brennan 1/24/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables
    public Text healthText;
    public Slider healthSlider;
    public Text timerText;
    public float speed;


    
    private int health = 50;
    private bool cursorBool = true;
    private Rigidbody rb;
   
    // Use this for initialization
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked; //locks cursor
        Cursor.visible = false; //makes cursor invisible
        rb = GetComponent<Rigidbody>(); //Initializes the Rigidbody with the component on the object 
    }

    // Update is called once per frame
    void Update()
    {
        HealthControl(); //Method to Control health details
        CursorLock(); //Method that controls Cursor's visibility and lock
        PlayerInput();//Method that controls inputs such as Reset or Exit

        //Controls the time text.
        timerText.text = "Time: " + (int)Time.timeSinceLevelLoad;


        //Variables for movement
        float xMove = Input.GetAxis("Horizontal");//Gets the x based off the mouse's x
        float zMove = Input.GetAxis("Vertical");//Gets the z vertical axis inputs

        //Movement and Rotation code
        Vector3 move;//Creates a vector 3 based on the inputs
        rb.transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);//Rotates the RB while moving. Based on the X axis. This also rotates the camera due to it being the child of the player.
        move = new Vector3(xMove, 0, zMove);//Movement vector 3
        transform.Translate(move * speed);//Uses translate to move the player
      
    }

    void PlayerInput()
    {
        //Resets the game.
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void CursorLock()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //Checks if left shift is clicked
        {
            if (cursorBool == true)//if bool true
            {
                Cursor.lockState = CursorLockMode.None;//unlocks the cursor
                Cursor.visible = true;//makes the cursor visible
                cursorBool = false; //makes boolean false
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; //locks cursor
                Cursor.visible = false;//makes cursor invisible
                cursorBool = true; //makes bool true
            }

        }
    }
   
    private void HealthControl()
    {
        //Controls the health displayed in text and the slider.
        healthSlider.value = health;
        healthText.text = "HP: " + health;
        //Resets if health is 0
        if (health <= 0)
        {
            //Loads scene 2 and sets the global variable to false
            GlobalVariables.winCondition = false;
            Cursor.lockState = CursorLockMode.None;//unlocks the cursor
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        //When colliding with a wall, the player loses 5 health. 
        if (collision.gameObject.tag == "Walls")
        {
            //Subtracts 5 each time we hit a wall.
            health -= 5;
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Finish")
        {
            Debug.Log("Contact");
            //Loads scene 2 and sets global variables
            GlobalVariables.winCondition = true;
            GlobalVariables.timeEnd = Time.timeSinceLevelLoad;
            Cursor.lockState = CursorLockMode.None;//unlocks the cursor
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }
}
