using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : MonoBehaviour
{
    public PlayerProperties playerPr;
    public bool fire;
    public bool ice;
    public bool earth;

    private void Start()
    {        
        playerPr = GameObject.Find("Player").GetComponent<PlayerProperties>();
    }

    private void OnTriggerEnter(Collider other)
    {                
        if (other.CompareTag("Player")){            
            if (fire) {
                playerPr.ResetState();
                playerPr.fireState = true;
            }
            if (ice)
            {
                playerPr.ResetState();
                playerPr.iceState = true;
            }
            if(earth)
            {
                playerPr.ResetState();
                playerPr.earthState = true;
            }
            Destroy(gameObject);
        }
    }
}
