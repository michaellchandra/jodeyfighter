using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosingDifficulty : MonoBehaviour
{
    public void PlayEasy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
    }

    public void PlayHard()
    {
        
    }
}
