using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    //UI ELEMENTS
    public Text playerHealthText;
    public Text playerElementText;
    public Text scoreText;
    public GameObject gameOverUI;

    //REFERENCES
    private PlayerProperties playerPropertiesS;
    private gameManager gmanagerScript;

        
    void Start()
    {
        //Assign references
        playerPropertiesS = GameObject.Find("Player").GetComponent<PlayerProperties>();
        gmanagerScript = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }



    
    void Update()
    {
        UpdateHealthUI();
        UpdateStateUI();
        UpdateScoreUI();
        if (gmanagerScript.gameOver)
        {
            gameOverUI.SetActive(true);
        }
    }



    //Update the amount of health the player has
    private void UpdateHealthUI()
    {        
        float currentHP = playerPropertiesS.health;
        playerHealthText.text = "HP: " + currentHP;
    }



    private void UpdateStateUI()
    {        
        string currentstate;
        if (playerPropertiesS.iceState)
        {
            currentstate = "Ice";
        }
        else if (playerPropertiesS.fireState)
        {
            currentstate = "Fire";
        }
        else if(playerPropertiesS.earthState)
        {
            currentstate = "Earth";
        }
        else
        {
            currentstate = "";
        }
        playerElementText.text = "Element: " + currentstate;
    }

    
    private void UpdateScoreUI()
    {
        float currentScore = gmanagerScript.score;
        scoreText.text = "Score " + currentScore;
    }

}
