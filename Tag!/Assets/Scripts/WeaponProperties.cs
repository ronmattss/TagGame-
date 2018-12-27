using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProperties : MonoBehaviour
{

   public bool isMelee = false;
    public bool isRange = false;
    public int damage = 10;
    
    public float force = 3f;
    public GameObject projectile;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //spawn a fucking pebble as a projectile
        // also need a weapon manager for switching weapons
        if(isRange == true)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("boom!");
        } 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMelee == true)
        {
            if (collision.transform.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Properties>().Health -= damage;
                this.gameObject.GetComponentInParent<Properties>().Health += damage +10;
               
                Debug.Log("Slash!" + collision.gameObject.name);
            }

        }
    }

}
