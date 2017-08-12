using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private Rigidbody rigid;
    bool jump = false;
    Vector3 mySpeed;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame    
    void FixedUpdate()
    {
        rigid.velocity = mySpeed;
        mySpeed = (Vector3.down * 9.81f);
        mySpeed += transform.forward * 20 * Input.GetAxis("Vertical");
        //mySpeed.y = rigid.velocity.y;
        
        if (Input.GetKeyDown(KeyCode.Space));
        {
            jump = !jump;       
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddRelativeForce(0f, 0f, 1000f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddRelativeForce(0f, 0f, -800f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddTorque(0f, -1000f * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddTorque(0f, 1000f * Time.deltaTime, 0f);
        }
        
        transform.Rotate(0f, 200f * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);

        if (jump)
        {
            rigid.AddRelativeForce((Vector3.up + Vector3.forward / 2) * 100f);
        }
    }
}



