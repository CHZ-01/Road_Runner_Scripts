using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Animator Animate;
    [SerializeField] CapsuleCollider col;

    int current_track = 0;
    bool alive = true;
    bool jumping = false;
    bool sliding = false;

    void Start()
    {
        alive = true;
        current_track = 0; //center
        PlayerPrefs.SetInt("coins", 0); //coins collected
    }

    void Update()
    {
        //Game start
        if(alive)
        {
            //character jump
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(jumping == false && sliding == false)
                {
                    StartCoroutine(jump());//jump animation
                    StartCoroutine(jump_size());//jump size
                }
            }

            //character slide
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (jumping == false && sliding == false)
                {
                    StartCoroutine(Roll());//slide animation
                }
            }

            //track movement
            if (current_track == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_track = 1; //left
                    StartCoroutine(left_side());
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_track = 2; //right
                    StartCoroutine(right_side());
                }
            }
            else if (current_track == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_track = 0; //center
                    StartCoroutine(right_side());
                }
            }
            else if (current_track == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_track = 0; //center
                    StartCoroutine(left_side());
                }
            }

            //character animation Jump
            IEnumerator jump()
            {
                jumping = true;
                Animate.SetInteger("Jump", 1);

                yield return new WaitForSeconds(0.8f);

                jumping = false;
                Animate.SetInteger("Jump", 0);
            }

            IEnumerator jump_size()
            {
                col.height = 1f;//changed height
                col.radius = 0.2f;//changed radius

                yield return new WaitForSeconds(0.7f);

                col.height = 2.7f;//original hieght
                col.radius = 0.7f;//original radius
            }

            //character animation left side
            IEnumerator left_side()
            {
                Animate.SetInteger("Left", 1);
                yield return new WaitForSeconds(0.2f);
                Animate.SetInteger("Left", 0);
            }

            //character animation right side
            IEnumerator right_side()
            {
                Animate.SetInteger("Right", 1);
                yield return new WaitForSeconds(0.2f);
                Animate.SetInteger("Right", 0);
            }

            //character animation Roll
            IEnumerator Roll()
            {
                sliding = true;
                col.height = 0f;//changed height
                col.radius = 0f;//changed radius
                Animate.SetInteger("Roll", 1);

                yield return new WaitForSeconds(0.6f);

                sliding = false;
                col.height = 2.7f;//original hieght
                col.radius = 0.7f;//original radius
                Animate.SetInteger("Roll", 0);
            }

        }//game start
    }

    //Trigger Game over
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Object"))
        {
            alive = false;
            Animate.applyRootMotion = true;
            Animate.SetInteger("Dead", 1);//dead animation
        }
    }
}
