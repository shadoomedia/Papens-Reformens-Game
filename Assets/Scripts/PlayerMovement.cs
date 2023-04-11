using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //Main Movement
    Rigidbody rb;
    [SerializeField] float movementSpeed = 300;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float rotationSpeed = 80;
    bool isJumping;
    float speedGeneral;

    //Audio
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource enemyDeathSound;
    [SerializeField] AudioSource playerStick;
    [SerializeField] AudioSource collect;
    [SerializeField] AudioSource iddleSound;
    public AudioSource movingSound;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        //turn player input
        float horizontalInput = Input.GetAxis("Horizontal");
        //move player input
        float verticalInput = Input.GetAxis("Vertical");

        //jump input & conditions
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            JumpMove(1f);
            isJumping = true;

        }

    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        //fwd
        Vector3 velocity = (transform.forward * verticalInput) * movementSpeed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        //bck
        if (verticalInput < 0)
        {
            horizontalInput = -horizontalInput;
        }

        //orientation
        transform.Rotate((transform.up * horizontalInput) * rotationSpeed * Time.fixedDeltaTime);
        
        speedGeneral= rb.velocity.magnitude;
        
       
        
        movingSound.pitch = speedGeneral*0.15f;
        movingSound.volume = speedGeneral*0.10f;
        
        
        


    }
    private void OnCollisionEnter(Collision other)
    {

        //Platform stick
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MovingPlatform"))
        {
            playerStick.Play();
            isJumping = false;
        }
        

        //Kill enemy condition
        if (other.gameObject.CompareTag("Enemy Head"))
        {
            enemyDeathSound.Play();
            Destroy(other.transform.parent.gameObject,0.1f);
            JumpMove(1.2f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            collect.Play();
        }

        if (other.gameObject.CompareTag("winflag"))
        {

        }
    }


    void JumpMove(float jumpMultiplier) //Jump function
    {
        rb.velocity = Vector3.up * jumpForce * jumpMultiplier;
        jumpSound.Play();
        
    }

}
