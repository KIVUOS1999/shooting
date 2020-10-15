using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstst_person_movement : MonoBehaviour
{

    public GameObject cam;
    public CharacterController controller;
    public float speed;
    public float Mouse_sensitivity;
    float x_rotation = 0;
    float gravity = 100.81f;
    public float jump_force = 10f;
    public GameObject ground_check;
    public LayerMask what_is_ground;
    Vector3 velocity;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {

        bool is_grounded = Physics.CheckSphere(ground_check.transform.position, 4f, what_is_ground);
        float mouse_x = Input.GetAxis("Mouse X") * Mouse_sensitivity *Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * Mouse_sensitivity * Time.deltaTime;
Debug.Log(is_grounded);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        //animations
        /*if (x != 0 || y != 0)
        {
            animator.SetBool("is_walkiing", true);
        }

        else
        {
            animator.SetBool("is_walkiing", false);
        }*/

        //this rotate camera vertically
        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
         
        //This rotate horizontally
        transform.Rotate(Vector3.up * mouse_x);


        //movement
        Vector3 MoveTowards = transform.right * x + transform.forward * y;
        controller.Move(MoveTowards * speed * Time.deltaTime);

        //jump
        if (is_grounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") )
        {
            velocity.y = Mathf.Sqrt(2 * gravity * jump_force);
        }

        velocity.y += -4 * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }
}
