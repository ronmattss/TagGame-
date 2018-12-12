using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagLogic : MonoBehaviour {


    // Logic
    // GameObject (empty) should touch the tagged entity (enemy/player)
    // if tagged for prototype, disable it
    bool isTagger = true;
    
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //logic for tagging

    private void OnCollisionStay2D(Collision2D collision)
    {
       // for prototype disable other gameobjects using "k" key;
        if (Input.GetKeyDown("k"))
        {
            collision.transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("k"))
        {
            collision.transform.gameObject.SetActive(false);
        }
    }
}
