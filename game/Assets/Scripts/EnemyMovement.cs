using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform firePointEnemy;
    public Animator Anim;
    public KeyCode JumpEnemy;
    public KeyCode RightMoveEnemy;
    public KeyCode LeftMoveEnemy;
    public KeyCode ShootEnemy;
    public GameObject bulletPrefabEnemy;
    public bool WalkingEnemy = false;
    public float MoveSpeedEnemy = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //jumping
        if (Input.GetKeyDown(JumpEnemy))
        {
            Anim.Play("JumpEnemy");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
        }

        //moving to the right
        if (Input.GetKeyDown(RightMoveEnemy))
        {
            Anim.Play("WalkingIntroEnemy");

            Anim.Play("WalkingEnemy");
        }


        //moving to the left
        if (Input.GetKeyDown(LeftMoveEnemy))
        {
            Anim.Play("WalkingReverseEnemy");
        }

        //shooting
        if (Input.GetKeyUp(ShootEnemy))
        {
            Anim.Play("ShootingEnemy");
            Instantiate(bulletPrefabEnemy, firePointEnemy.position, firePointEnemy.rotation);

        }

        //if shoot key is released
        if (Input.GetKeyUp(ShootEnemy))
        {
            Anim.Play("IdleEnemy");
        }


        //if Right move key is released
        if (Input.GetKeyUp(RightMoveEnemy))
        {
            Anim.Play("IdleEnemy");
        }

        //if left move key is released
        if (Input.GetKeyUp(LeftMoveEnemy))
        {
            Anim.Play("IdleReverseEnemy");
        }


        //player movement
        float move_X_enemy = Input.GetAxis("HorizontalEnemy");

        Vector2 movementEnemy = new Vector2(move_X_enemy * MoveSpeedEnemy, 0);

        movementEnemy *= Time.deltaTime;

        transform.Translate(movementEnemy);
    }
}
