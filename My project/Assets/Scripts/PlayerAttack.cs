using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] attacksAvailable = new GameObject[4];
    public GameObject currentAttack;
    public Vector3 attackPointOffset;

    //REFERENCES
    public GameObject attackPoint;
    public GameObject pCamera;

    // Start is called before the first frame update
    void Start()
    {        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            launchAttack();
        }
    }



    //HELPER METHODS
    private void launchAttack()
    {
        Instantiate(currentAttack, attackPoint.transform.position, pCamera.transform.rotation);
    }
}
