using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    States state;
    Rigidbody rb;
    bool grounded;
    float idleMovement = 0;
    public GameObject cylinder; //body of player


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
    }


    void DoLogic()
    {
        if( state == States.Idle )
        {
            PlayerStanding();
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


    void PlayerStanding()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3( 0,10,0);
        }

        if( Input.GetKey("left"))
        {
            transform.Rotate( 0, 0.5f, 0, Space.Self );

        }
        if( Input.GetKey("right"))
        {
            transform.Rotate( 0,-0.5f, 0, Space.Self );
        }

        if( Input.GetKey("up"))
        {
            state = States.Walk;
        }

        //do idle movement
        float offset = Time.time % 1f;
        if ( offset > 0.5f )
        {
            offset = 1.0f-offset;
        }
        offset /= 4;
        cylinder.transform.position = new Vector3(cylinder.transform.position.x, offset, cylinder.transform.position.z);


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

        //magnitude is the player's speed
        float magnitude = rb.velocity.magnitude;

        rb.AddForce(transform.forward * 5f);
    }


    void OnCollisionEnter( Collision col )
    {
        if( col.gameObject.tag == "Floor")
        {
            grounded=true;
            print("landed!");
        }
    }


    private void OnGUI()
    {
        string text = "Left/Right arrows = Rotate\nSpace = Jump\nUp Arrow = Forward\nCurrent state=" + state;

        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();


    }



}
