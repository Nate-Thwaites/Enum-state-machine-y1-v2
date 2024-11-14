using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;

public enum States // used by all logic
{
    None,
    Idle,
    Walk,
    Jump,
    Dead,
};

public class PlayerScript : MonoBehaviour
{
    States state;


    Rigidbody rb;
    bool grounded;
    bool dead;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }

    void FixedUpdate()
    {
        grounded=false;
        dead=false;
    }


    void DoLogic()
    {
        if( state == States.Idle )
        {
            PlayerIdle();
        }

        if( state == States.Jump )
        {
            PlayerJumping();
        }

        if( state == States.Walk )
        {
            PlayerWalk();
        }
    }


    void PlayerIdle()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3( 0,10,0);
        }

        if( Input.GetKey("right"))
        {
            transform.Rotate( 0, 0.5f, 0, Space.Self );

        }
        if( Input.GetKey("left"))
        {
            transform.Rotate( 0,-0.5f, 0, Space.Self );
        }

        if( Input.GetKey("up"))
        {
            state = States.Walk;
           
        }
    }

    void PlayerJumping()
    {
        // player is jumping, check for hitting the ground
        if( grounded == true )
        {
            //player has landed on floor
            state = States.Idle;
        }
    }

    void PlayerWalk()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5f);

        //magnitude = the player's speed
        float magnitude = rb.velocity.magnitude;



        if (Input.GetKey("up") == true)
        {
            rb.AddForce(transform.forward * 5f);
        }

        if (Input.GetKey("up") == false)
        {
            if (magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
                state = States.Idle;
            }

        }
       


            
            

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);

        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }
    }


    /*void OnCollisionEnter( Collision col )
    {
        if( col.gameObject.tag == "Floor")
        {
            grounded=true;
            print("landed!");
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            state = States.Dead;
            dead =true;
            rb.velocity = new Vector3(0, 50, 0);
            Task.Delay(2000);
            SceneManager.LoadScene("Demo");
            
        }

       

        
        

        
    }


    private void OnGUI()
    {
        //debug text
        string text = "Left/Right arrows = Rotate\nSpace = Jump\nUp Arrow = Forward\nCurrent state=" + state;

        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();
    }
}
