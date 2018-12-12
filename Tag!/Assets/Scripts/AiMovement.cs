using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class AiMovement : MonoBehaviour {

    // what to chase
    public Transform target;

    // n times each second to update path
    public float updateRate = 2f;
    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    // calculated path
    public Path path;
    //jump value and bool
    public bool isGrounded = true;
    public float jumpForce;


    //speed of ai
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // max distance from the ai to a waypoint to continue to the next waypoint
    public float nextWaypointDistance = 3;
    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target == null)
        {
            Debug.LogError("No Player found?");
            this.gameObject.SetActive(false);
            
            return;
        }
 

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            // TODO: Insert a player search here.
          yield  return  false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }


    public  void OnPathComplete(Path p)
    {
        Debug.Log("Got a path. does we have an error?" + p.error);
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    private void FixedUpdate()
    {
        if (target == null)
        {
            // TODO: Insert a player search here.
             return;
        }

        //TODO: Always look at player??? lol dk
        if (path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            if(pathIsEnded)
               return;
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
            
        }

        pathIsEnded = false;

        // find Direction to the next waypoint
        float x = path.vectorPath[currentWaypoint].x - transform.position.x;
        float y = path.vectorPath[currentWaypoint].y - transform.position.y;
        float z = path.vectorPath[currentWaypoint].z - transform.position.z;
        Vector3 dir;


        // jump if target is in a higher platform
        if ((isGrounded == true) && path.vectorPath[currentWaypoint].y < target.position.y)
        {
           dir = new Vector3(x, y* jumpForce, z);
            Debug.Log(dir.y +"NICE WAT");
            isGrounded = false;

        }
        else
        {
           dir = new Vector3(x, y*0, z);
            Debug.Log(dir.y + " !WAT");
            isGrounded = false;


        }
        dir *= speed * Time.fixedDeltaTime;
        
        rb.AddForce(dir, fMode);
        

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "floor")
            this.isGrounded = true;
        else
        {
            this.isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;  
    }
}
