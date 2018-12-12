using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class AiScript : MonoBehaviour
{
    // prototype movement
    // Ai will just move around the scene
    // Use this for initialization
    [Header("Movement Properties")]
    public CharacterController2D AiMovement;
    public float runSpeed = 100f;
    float horizontalMove = 0f;
    [Header("Targets")]
    public GameObject player;
    bool jump = false;
    bool crouch = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
      //  MoveToPlayer(player);
        AiMovement.Move((horizontalMove * runSpeed) * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        Debug.Log(jump);
    }


    // collision detecting for shitty prototype
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            collision.gameObject.SetActive(false);
            if (horizontalMove == 1f)
            {

                horizontalMove = -1f;
                Debug.Log("collided with" + collision.gameObject.tag);


            }
            else
            {

                horizontalMove = 1f;

            }

        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (horizontalMove == 1f)
            {

                horizontalMove = -1f;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Force);
                
                Debug.Log("collided with" + collision.gameObject.tag);


            }
            else
            {

                horizontalMove = 1f;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Force);

            }
            StartCoroutine(EnableComponent(gameObject.GetComponent<BoxCollider2D>(),gameObject.GetComponent<CircleCollider2D>()));
        }

    }
    IEnumerator EnableComponent(BoxCollider2D _colliderBox, CircleCollider2D _colliderCircle)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        _colliderBox.enabled = true;
        _colliderCircle.enabled = true;
    }


    // move towards player prototype code (Noob Ai)
    // Pathfinding algorithm will be used for better Ai

    void MoveToPlayer(GameObject _player)
    {
        GameObject enemy = this.gameObject;
        
        // if enemy is on the right side of the player with same y coordinates 
        if(enemy.transform.position.x > _player.transform.position.x && enemy.transform.position.y == _player.transform.position.y)
        {
            horizontalMove = -1f;
        }

        // if enemy is on the left side of the player with same y coordinates
        else if (enemy.transform.position.x < _player.transform.position.x && enemy.transform.position.y == _player.transform.position.y)
        {
            horizontalMove = 1f;
        }
        else if (enemy.transform.position.x == _player.transform.position.x && enemy.transform.position.y == _player.transform.position.y)
        {
            horizontalMove = 0f;
        }

        // find the position of Player through the Y axis
        else if (enemy.transform.position.x > _player.transform.position.x &&  enemy.transform.position.y > _player.transform.position.y)
        {
            horizontalMove = -1f;
            
        }
        else if (enemy.transform.position.x < _player.transform.position.x && enemy.transform.position.y > _player.transform.position.y)
        {
            horizontalMove = 1f;
            
        }

        else if (enemy.transform.position.y <= _player.transform.position.y)
        {
            // jump 
            // make a trigger for platforms that enable the jump if player.y is > enemy.y
            
            jump = true;
            Debug.Log(jump);
        }

    }
}
