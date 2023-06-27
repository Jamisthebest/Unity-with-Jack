using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //All basic values
    public float basePlayerHealth = 100;
    public int collisionDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (basePlayerHealth <= 0 ){
            Application.Quit();
        } 
    }

    void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.name == "Stormtrooper") // if there is a collision with the gameObject with name "Floor"
        {   // minuses HP 
            basePlayerHealth -= collisionDamage;
        }
    }
}
