using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    void OnTriggerEnter2D(Collider2D other) 
    {  
            StartCoroutine(LoadNextLevel());  
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
