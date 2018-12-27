using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{

    // Script for properties and powerups, debuffs, and shits for the player
    // Start is called before the first frame update
    public int Health;
    // player or enemy;
    public GameObject entity;


    //Enemy Attack Property
    public bool canAttack = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // update Player UI health if damaged or healed
        if (this.gameObject.name == "Player")
        {
            Debug.Log("Player Health: " + Health);
            if (Health < 0)
            {
                this.transform.gameObject.SetActive(false);
            }
            else if (Health > 100)
            {
                Health = 100;
            }
        }
        if(Health <=0)
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canAttack == true)
        {
            // collision.otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
            if (collision.transform.tag == "Player")
            {
                collision.gameObject.GetComponent<Properties>().Health -= 10;
                Debug.Log("HIT" + collision.gameObject.name);
            }
            else { }
        }
    }
}
