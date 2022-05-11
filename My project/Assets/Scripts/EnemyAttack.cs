using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //VARIABLES
    public Vector3 attackPointOffset;
    public float attackCooldownSeconds;
    public bool attacking;


    //REFERENCES
    public GameObject attackType;
    public GameObject attackPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if (attackType.CompareTag("Ice Attack"))
        {
            if (!attacking)
            {
                performIceAttack();
                attacking = true;
            }
            if (attacking)
            {
                StartCoroutine(AttackCooldown());
                attacking = false;
                Debug.Log("Coroutine done");
            }
        }
    }



    //Routine for attack cooldown
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownSeconds);
    }


    //HELPER METHODS
    private void performIceAttack()
    {        
        //Instantiate(attackType, attackPoint.transform.position + attackPointOffset, transform.rotation);
        Debug.Log("Attacking");        
    }
}
