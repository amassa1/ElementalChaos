using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //VARIABLES    
    public float followDistance;
    public float stopFollowingDistance;
    bool playerInSight;

    //REFERENCES
    public GameObject attackPoint;
    GameObject player;
    GameObject centralAsteroid;
    EnemyProperties properties;


    // Start is called before the first frame update
    void Start()
    {
        properties = gameObject.GetComponent<EnemyProperties>();
        player = GameObject.Find("Player");
        centralAsteroid = GameObject.Find("Central Asteroid");
        InvokeRepeating("attack", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        float distanceFromAsteroid = Vector3.Distance(transform.position, player.transform.position);


        
        //If the player is within the range, follow the player
        if (distanceFromPlayer <= followDistance && distanceFromPlayer > stopFollowingDistance) //In this state the enemy is following the player
        {
            playerInSight = true;
            goTo(player);
        }
        //Once the enemy reaches a certain distance from the player, start attacking him
        else if (distanceFromPlayer < stopFollowingDistance) //In this state the enemy has reached the position where is is attacking the player
        {
            //Stop moving

        }
        else
        {
            playerInSight = false;
            goTo(centralAsteroid);
        }
    }


    //HELPER METHODS
    void goTo(GameObject target)
    {
        //Get object current position
        Vector3 targetV = target.transform.position;
        //Move to that position
        transform.Translate((targetV - transform.position).normalized * properties.speed * Time.deltaTime);
        //Rotate enemy towards that position
        var q = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 1000 * Time.deltaTime);
    }
    

    void attack()
    {
        if (playerInSight)
        {
            Instantiate(properties.attacktype, attackPoint.GetComponent<Transform>());
        }        
    }
    

}
