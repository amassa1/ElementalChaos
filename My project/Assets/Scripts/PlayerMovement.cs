using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed = 10;
    public float normalSpeed = 10;
    public float sprintSpeed = 20;
    public float staminaDrainRate = 2;
    public float staminaRecoverRate = 5;    
    public float jumpForce;
    public bool isOnGround;
    public bool isSprinting;
    public float gravityForce;
    private float xAxis;
    private float zAxis;    

    //References
    Rigidbody playerRigidBody;
    PlayerProperties playerProperties;

    void Start()
    {                
        //Set references
        playerRigidBody = GetComponent<Rigidbody>();
        playerProperties = GetComponent<PlayerProperties>();
        Physics.gravity *= gravityForce;
        isOnGround = true;       
    }


    
    void Update()
    {

        //Assign the 2 axes based on inputs
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");      

        //Move player in 4 direction
        MoveOnX(xAxis);
        MoveOnZ(zAxis);        

        //Allow player to jump if he is on the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                Jump();
            }            
        }

        /*Allow the player to sprint and make sure to take off stamina points as they speed
          Add stamina points if the player is not sprinting                                 */
        if (Input.GetKey(KeyCode.LeftShift)){ 
            if (playerProperties.stamina > 0){            
                isSprinting = true;                
            }
            else
            {
                isSprinting = false;
            }
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            Sprint();
        }
        if (!isSprinting)
        {
            Recover();
        }
    }





    //HELPER METHODS    
    private void MoveOnX(float axis)
    {
        transform.Translate(new Vector3(axis * speed * Time.deltaTime, 0, 0));     
    }

    private void MoveOnZ(float axis)
    {
        transform.Translate(new Vector3(0, 0, axis * Time.deltaTime * speed));
    }

    private void Jump()
    {        
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    private void Sprint()
    {
        speed = sprintSpeed;
        playerProperties.stamina -= Time.deltaTime * staminaDrainRate;
    }

    private void Recover()
    {
        speed = normalSpeed;
        if (playerProperties.stamina < 100)
        {
            playerProperties.stamina += Time.deltaTime * staminaRecoverRate;
        }
    }

    //COLLISIONS
    private void OnCollisionEnter(Collision collision)
    {
        //if player is on the ground, should be allowed to jump
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
    }    
}
