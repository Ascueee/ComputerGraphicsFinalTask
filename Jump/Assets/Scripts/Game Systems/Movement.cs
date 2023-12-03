using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Var")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] float jumpForce;
    [SerializeField] float moveForce;
    [SerializeField] float jumpTimer;
    [SerializeField] float stateOne,stateTwo,stateThree;
    [SerializeField] bool isGrounded;
    Vector3 movement;
    float horizontalInput;
    bool inTimer;
    bool inJump;
    float resetTimer;

    [Header("Other Componenets")]
    [SerializeField] GameObject playerObj;
    [SerializeField] CameraController cc;
    [SerializeField] EndingManager em;
    [SerializeField] LightOnOff lc;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        playerObj.GetComponent<Renderer>().material.color = Color.magenta;
        resetTimer = jumpTimer;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        InTimer();
    }

    private void FixedUpdate()
    {


        if (inJump)
        {
            Jump();
        }

        PlayerMovement();

    }

    void PlayerInput()
    {

        if (Input.GetKeyDown(jumpKey) && isGrounded == true)
        {
            inTimer = true;
        }

        if (Input.GetKeyUp(jumpKey) && isGrounded == true)
        {
            inTimer = false;
            inJump = true;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    ///------------ MOVEMENT METHODS ------------
    void InTimer()
    {
        if(inTimer == true)
        {
            jumpTimer -= Time.deltaTime;

            if(jumpTimer <= 0)
            {
                jumpTimer = 0;
            }
        }
    }

    private void PlayerMovement()
    {
        movement.Set(0f, 0f, horizontalInput);
        movement = movement * moveForce * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
    void Jump()
    {
        if(jumpTimer >= stateOne)
        {
            rb.AddForce(transform.up * (jumpForce * 0.25f), ForceMode.Impulse);
            playerObj.GetComponent<Renderer>().material.color = Color.red;

            isGrounded = false;
            inJump = false;
            jumpTimer = resetTimer;
        }
        else if(jumpTimer < stateOne && jumpTimer >= stateTwo)
        {
            rb.AddForce(transform.up * (jumpForce * 0.5f), ForceMode.Impulse);
            playerObj.GetComponent<Renderer>().material.color = Color.blue;

            isGrounded = false;
            inJump = false;
            jumpTimer = resetTimer;
        }
        else if(jumpTimer < stateOne && jumpTimer < stateTwo && jumpTimer >= stateThree)
        {
            rb.AddForce(transform.up * (jumpForce * 0.8f), ForceMode.Impulse);
            playerObj.GetComponent<Renderer>().material.color = Color.black;

            isGrounded = false;
            inJump = false;
            jumpTimer = resetTimer;
        }
    }

    ///------------ MOVEMENT METHODS ENDS ------------ <summary>


    private void OnCollisionEnter(Collision collision)
    {
        //checks all the collision points to see if the player is ontop of the ground
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            if (collision.contacts[i].normal.y > 0.5)
            {
                isGrounded = true;
                playerObj.GetComponent<Renderer>().material.color = Color.magenta;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TopCam")
        {
            print("top cam hit");
            cc.IncrementIndex();
        }

        if(other.gameObject.tag == "BotCam")
        {
            print("Bot cam hit");
            cc.DecrementIndex();
        }

        if(other.gameObject.tag == "Finish")
        {
            lc.finalLight = true;
            em.isFinished = true;
            print("this is running");
        }
    }



}
