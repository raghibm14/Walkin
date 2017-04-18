using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour {
    CharacterController c;
    float rotateSpeed;
    public float walkSpeed;
    public bool canwalk;
    void Start () {
        c = GetComponent<CharacterController>();
        rotateSpeed =  3.0f;
        canwalk = true;
    }
	
	void Update () {
       
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && canwalk )
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        }
        else
        if (Input.GetKey(KeyCode.UpArrow) && canwalk)
        {
            
            c.SimpleMove(Camera.main.transform.forward * walkSpeed);
        }
        else
        if (Input.GetKey(KeyCode.DownArrow) && canwalk)
        {

            c.SimpleMove(-Camera.main.transform.TransformDirection(Vector3.forward) * walkSpeed);
        }

        if(!c.isGrounded)
        {
            c.Move(new Vector3(0,-50,0));
        }
    }
}
