using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackBehavior : MonoBehaviour
{
    //VARIABLES
    public float projectileSpeed = 2;
    public float attackLifeDuration = 10;
    public float baseDamage = 10;

    //REFERENCES

    // Start is called before the first frame update
    void Start()
    {
        //Sart the countdown of 10 seconds that destroys the floating ice shard
        StartCoroutine(expireAttack());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }



    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }


    //Couroutine that destroys the object
    IEnumerator expireAttack()
    {
        yield return new WaitForSeconds(attackLifeDuration);
        Destroy(gameObject);
    }

}
