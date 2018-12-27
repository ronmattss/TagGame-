using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour {
    public Transform someObject;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    float xCoordinate;
    float yCoordinate;
    public GameObject[] gameObjects;
    


	// Use this for initialization
	void Start () {
        
		
	}
    private void Awake()
    {
        someObject.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.T))
        {
            xCoordinate = Random.Range(minX, maxX);
            yCoordinate = Random.Range(minY, maxY);
            
            Instantiate(someObject,new Vector3( xCoordinate,yCoordinate,0), Quaternion.identity);
        }

        //check if these gameobjects are disabled
        foreach (GameObject _objects in gameObjects)
        {
            if(_objects.activeInHierarchy == false)
            {
                
                
                Debug.Log(_objects.tag + "is not active");

                StartCoroutine(WaitTime(_objects));
                
                
            }
            
        }
		
	}
    // define a Coroutine to wait for N seconds then activate a gameobject
    IEnumerator WaitTime(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(true);
        //Debug.Log("is This working?");
    }



}
