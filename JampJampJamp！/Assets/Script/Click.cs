using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{    
    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }

    public void Game()
    {
        SceneManager.LoadScene("GameScene");
    }
}
