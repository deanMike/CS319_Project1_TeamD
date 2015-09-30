using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

/*    public float speed = 17.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
  */
   CharacterController controller;

     // Use this for initialization
     void Start () {
        // transform.position = new Vector3(150, 15, 100);
         controller = GetComponent<CharacterController>();

     }

     // Update is called once per frame
     void Update () {
         if (controller.isGrounded) {
             if (Input.GetKey("w")) {
                 controller.Move(new Vector3(0, 0, 3));
             }
             if (Input.GetKey("s")) {
                 controller.Move(new Vector3(0, 0, -3));
             }
             if (Input.GetKey("a")) {
                 controller.Move(new Vector3(-3, 0, 0));
             }
             if (Input.GetKey("d")) {
                 controller.Move(new Vector3(3, 0, 0));
             }
         }
     }
}
    
