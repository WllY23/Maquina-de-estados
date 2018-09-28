using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : FPSAim
{
    public float speed;

    public Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
    }

	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
           // transform.position -= transform.right * speed * Time.deltaTime;
            transform.Rotate(0, -10, 0);
            anim.SetTrigger("walk");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 10, 0);
           // transform.position += transform.right * speed * Time.deltaTime;
            anim.SetTrigger("walk");
        }
       else if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward* speed * Time.deltaTime;
            anim.SetTrigger("walk");
        }
        else if (Input.GetKey(KeyCode.S))
        {
			transform.position -= transform.forward * speed * Time.deltaTime;
            anim.SetTrigger("walk");
        }
        
        else
        {
            anim.SetTrigger("idle");
        }
    }
}
