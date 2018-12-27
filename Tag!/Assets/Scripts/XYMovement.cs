using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYMovement : MonoBehaviour
{ 
    public float runSpeed = 40f;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public GameObject player;
    public GameObject weapon;
    Vector2 move;
    Vector2 mouseScreenPosition;
    Vector2 direction;



    // Start is called before the first frame update
    void Start()
    {
       player.GetComponent<Rigidbody2D>();
       


        
    }

    // Update is called once per frame
    void Update()
    {
        mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        
        
            move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    private void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().AddForce(move*runSpeed);
        //if (Input.GetMouseButtonDown(0))
            weapon.transform.up = direction;

    }
}
