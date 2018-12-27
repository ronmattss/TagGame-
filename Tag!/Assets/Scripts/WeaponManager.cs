using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    //check equipped weapons
    // limit to n weapons?
    // disable/ enable weapons 
         GameObject weaponHolder;
    public GameObject[] weapons;
  // public List<GameObject> weapons = new List<GameObject>();
    void Start()
    {
        weaponHolder = this.gameObject;
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        
        
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.SetActive(false);
            }
        }
    }

    // Update is called once per frame

}
