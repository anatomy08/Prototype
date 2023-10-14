using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    
    AudioSource finish;

    void Start()
    {
        finish = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {  
        finish.Play();
        StartCoroutine(LoadNextLevel());  
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
