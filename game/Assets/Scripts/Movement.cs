using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform firePoint;
    public Animator Anim;
    public KeyCode Jump;
    public KeyCode RightMove;
    public KeyCode LeftMove;
    public KeyCode Shoot;
    public GameObject bulletPrefab;
    public bool Walking = false;
    public float MoveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //jumping
        if (Input.GetKeyDown(Jump))
        {
            Anim.Play("Jump");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
        }
        
        //moving to the right
        if (Input.GetKeyDown(RightMove))
        {
            Anim.Play("WalkingIntro");

            Anim.Play("Walking");
        }


        //moving to the left
        if (Input.GetKeyDown(LeftMove))
        {
            Anim.Play("WalkingReverse");
        }

        //shooting
        if (Input.GetKeyUp(Shoot))
        {
            Anim.Play("Shooting");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }

        //if shoot key is released
        if (Input.GetKeyUp(Shoot))
        {
            Anim.Play("Idle");
        }


        //if Right move key is released
        if (Input.GetKeyUp(RightMove))
        {
            Anim.Play("Idle");
        }

        //if left move key is released
        if (Input.GetKeyUp(LeftMove))
        {
            Anim.Play("IdleReverse");
        }


        //player movement
        float move_X = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(move_X * MoveSpeed, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);



    }
}
