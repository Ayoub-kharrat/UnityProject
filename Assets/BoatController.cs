using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    //public Transform head;
    public Camera camera;



    [Header("References")]
    public float walkSpeed;
    public float runSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 cameraRotation = Vector3.zero;

    void FixedUpdate(){
        
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        cameraRotation.y = Input.GetAxis("Horizontal")* speed/14;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90, 90);
        rb.transform.Rotate(cameraRotation);


        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        //newVelocity.x =Input.GetAxis("Vertical")* speed;
        newVelocity.z =Input.GetAxis("Vertical")* speed;
        rb.velocity = transform.TransformDirection(newVelocity);

    }
}
