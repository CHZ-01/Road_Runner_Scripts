using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Rigidbody rb;
    [SerializeField] CapsuleCollider col;
    [SerializeField] GameObject Counter;
    [SerializeField] GameObject GameOver;

    RigidbodyConstraints og_constraints;
    public AudioSource Music;
    Game_Audio Audio_play;

    int current_track = 0;
    public float shift_speed;
    public float run_speed;
    public float max_speed;
    public float jump_force;
    public float jump_back;
    bool alive = true;
    bool jumping = false;
    bool sliding = false;

    void Start()
    {
        Cursor.visible = false;
        current_track = 0; //center
        alive = true;
        og_constraints = rb.constraints;//default constraints
        PlayerPrefs.SetInt("coins", 0);
        Music.Play();
    }

    private void Awake()
    {
        //SFX script call
        Audio_play = GameObject.FindGameObjectWithTag("Audio").GetComponent<Game_Audio>();
    }

    void Update()
    {
        //Game start
        if (alive)
        {
            //character run
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + run_speed * Time.deltaTime);

            //increase speed
            if (run_speed <= max_speed)
            {
                run_speed += 0.05f * Time.deltaTime;
                jump_back += 0.1f * Time.deltaTime;
            }

            //character jump
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (jumping == false && sliding == false)
                {
                    rb.velocity = Vector3.up * jump_force;
                    StartCoroutine(jump());//jump animation
                    StartCoroutine(jump_size());//jump size
                }
            }

            //character slide
            if (Input.GetKeyDown(KeyCode.DownArrow))
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
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_track = 2; //right
                }
            }
            else if (current_track == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_track = 0; //center
                }
            }
            else if (current_track == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_track = 0; //center
                }
            }

            //character movement
            if (current_track == 0)
            {
                if (Vector3.Distance(transform.position, new Vector3(center.position.x, transform.position.y, transform.position.z)) >= 0.5f)
                {
                    //center movement
                    Vector3 track = new Vector3(center.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(shift_speed * Time.deltaTime * track.normalized, Space.World);
                }
            }
            else if (current_track == 1)
            {
                if (Vector3.Distance(transform.position, new Vector3(left.position.x, transform.position.y, transform.position.z)) >= 0.5f)
                {
                    //left movement
                    Vector3 track = new Vector3(left.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(shift_speed * Time.deltaTime * track.normalized, Space.World);
                }
            }
            else if (current_track == 2)
            {
                if (Vector3.Distance(transform.position, new Vector3(right.position.x, transform.position.y, transform.position.z)) >= 0.5f)
                {
                    //right movement
                    Vector3 track = new Vector3(right.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(shift_speed * Time.deltaTime * track.normalized, Space.World);
                }
            }

            //character Jump
            IEnumerator jump()
            {
                jumping = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - jump_back * Time.deltaTime);

                yield return new WaitForSeconds(0.8f);

                jumping = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + run_speed * Time.deltaTime);
            }

            //jump size
            IEnumerator jump_size()
            {
                col.height = 1f;//changed height
                col.radius = 0.2f;//changed radius

                yield return new WaitForSeconds(0.7f);

                col.height = 2.7f;//original hieght
                col.radius = 0.7f;//original radius
            }

            //character Roll
            IEnumerator Roll()
            {
                sliding = true;
                col.height = 0;//changed height
                col.radius = 0.2f;//changed radius
                rb.constraints = RigidbodyConstraints.FreezeAll;

                yield return new WaitForSeconds(0.6f);

                sliding = false;
                col.height = 2.7f;//original hieght
                col.radius = 0.7f;//original radius
                rb.constraints = og_constraints;
            }

        }//game start
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision detection
        if (collision.gameObject.CompareTag("Object"))
        {
            Audio_play.Play_SFX(Audio_play.Dead);
            alive = false;
            Music.Pause();
            Counter.SetActive(false);
            GameOver.SetActive(true);
            Cursor.visible = true;
        }
    }

}
