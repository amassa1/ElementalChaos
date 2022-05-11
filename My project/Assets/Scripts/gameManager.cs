using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public float score;
    public bool gameOver;
    bool gameHasEnded = false;

    private void Start()
    {
        score = 0;   
    }

    private void Update()
    {       
        if (gameOver & (gameHasEnded == false))
        {
            EndGame();
            gameHasEnded = true;
        }
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        Invoke("Restart", 2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       
    }
}
