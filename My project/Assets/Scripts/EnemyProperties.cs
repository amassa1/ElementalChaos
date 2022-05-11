using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    //VARIABLES
    public float health = 100;
    public float speed;
    public bool iceEnemy;
    public bool fireEnemy;
    public bool groundEnemy;    
    

    //Refernces
    public GameObject attacktype;
    gameManager gameManagerS;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerS = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }




    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            die();            
        }
    }




    //COLLISIONS
    private void OnCollisionEnter(Collision collision)
    {
        float baseDamage = 0;
        float multiplier = 0;

        //Manage collision with ice attacks
        if (collision.gameObject.CompareTag("Ice Attack"))
        {
            baseDamage = collision.gameObject.GetComponent<AttackBehavior>().baseDamage;
            if (fireEnemy)
            {
                multiplier = 0.5f;
            }
            else if (iceEnemy)
            {
                multiplier = 1;
            }
            else
            {
                multiplier = 2;
            }                        
        }

        //Manage collision with fire attacks
        if (collision.gameObject.CompareTag("Fire Attack"))
        {            
            baseDamage = collision.gameObject.GetComponent<AttackBehavior>().baseDamage;
            if (fireEnemy)
            {
                multiplier = 1;
            }
            else if (iceEnemy)
            {
                multiplier = 2;
            }
            else
            {
                multiplier = 0.5f;
            }            
        }

        if (collision.gameObject.CompareTag("Earth Attack"))
        {            
            baseDamage = collision.gameObject.GetComponent<AttackBehavior>().baseDamage;
            if (fireEnemy)
            {
                multiplier = 2;
            }
            else if (iceEnemy)
            {
                multiplier = 0.5f;
            }
            else
            {
                multiplier = 1;
            }
        }

        if (collision.gameObject.CompareTag("Mother Asteroid"))
        {
            goToMotherAsteroid();
        }

        health = health - CalculateDamage(baseDamage, multiplier);
        Debug.Log("HP: " + health);        
    }




    //HELPER METHODS
    private float CalculateDamage(float baseDamage, float multiplier)
    {
        float damage = multiplier * baseDamage;
        return damage;
    }

    private void die()
    {
        gameManagerS.score++;
        Destroy(gameObject);
    }

    private void goToMotherAsteroid()
    {
        gameManagerS.score--;
        Destroy(gameObject);
    }
}
