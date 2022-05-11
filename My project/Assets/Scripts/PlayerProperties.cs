using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    //VARIABLES
    public float health = 100;
    public float stamina = 100;
    public bool fireState;
    public bool iceState;
    public bool earthState;

    //REFERENCES
    PlayerAttack playerAttackS;
    gameManager gmanagerS;
    

    void Start()
    {
        playerAttackS = gameObject.GetComponent<PlayerAttack>();
        gmanagerS = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }




    // Update is called once per frame
    void Update()
    {     

        if (health <= 0)
        {
            die();
        }

        //MANAGES THE ELEMENTAL STATE THE PLAYER IS IN
        if (fireState)
        {   
            playerAttackS.currentAttack = playerAttackS.attacksAvailable[1];
        }
        if (iceState)
        {            
            playerAttackS.currentAttack = playerAttackS.attacksAvailable[2];
        }
        if (earthState)
        {            
            playerAttackS.currentAttack = playerAttackS.attacksAvailable[3];
        }
    }


    //MANAGES COLLISIONS WITH DIFFERENT ATTACKS
    private void OnCollisionEnter(Collision collision)
    {
        float baseDamage = 0;
        float multiplier = 0;

            //Manage collision with ice attacks
            if (collision.gameObject.CompareTag("Ice Attack"))
            {
                baseDamage = collision.gameObject.GetComponent<AttackBehavior>().baseDamage;
                    if (fireState)
                    {
                         multiplier = 0.5f;
                    }
                    else if (iceState)
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
                if (fireState)
                {
                    multiplier = 1;
                }
                else if (iceState)
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
                if (fireState)
                {
                    multiplier = 2;
                }
                else if (iceState)
                {
                    multiplier = 0.5f;
                }
                else
                {
                    multiplier = 1;
                }
            }

        health = health - CalculateDamage(baseDamage, multiplier);
    }

    //HELPER METHODS
    private void die()
        {
            gmanagerS.gameOver = true;
        }

        public void ResetState()
        {
            fireState = false;
            iceState = false;
            earthState = false;
        }

    private float CalculateDamage(float baseDamage, float multiplier)
    {
        float damage = multiplier * baseDamage;
        return damage;
    }
}
