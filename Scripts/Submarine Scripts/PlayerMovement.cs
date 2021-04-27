using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movement Properties")]
    public float walkSpeed;
    public float runSpeed;
    public float gravity;
    public float jumpHeight;

    [Header("Ground Check Properties")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groudMask;

    private Animator anim;
    private CharacterController controller;
    private bool isGrounded;
    private Vector3 verticalVelocity;

    public float fireRate;
    //private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHorizontalMovement();
        CheckVerticalMovement();
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("LevelOne");
        }
        /*if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetTrigger("Swing");
        }
        if (Input.GetMouseButtonDown(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetTrigger("Block");
            anim.SetBool("HoldBlock", true);
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            anim.SetBool("HoldBlock", false);
        }
        */
    }

    private void CheckHorizontalMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //anim.SetFloat("BlendX", x);
        Vector3 movement = transform.right * x + transform.forward * y;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(movement * runSpeed * Time.deltaTime);
            //anim.SetFloat("BlendY", y * 2);
        }
        else
        {
            controller.Move(movement * walkSpeed * Time.deltaTime);
            //anim.SetFloat("BlendY", y);
        }
    }

    private void CheckVerticalMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groudMask);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //anim.SetTrigger("Jump");
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}
