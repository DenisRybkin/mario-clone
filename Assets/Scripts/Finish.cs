using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int currentLevel = 1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var isLastLevel = (SceneManager.sceneCountInBuildSettings - 1) == SceneManager.GetActiveScene().buildIndex;
            Debug.Log(isLastLevel);
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            PlayerPrefs.SetInt("level", currentLevel);
            SceneManager.LoadScene(1);
            /*if (isLastLevel)
            {
                
            }
            else
            {
                //var loadSceneIndex = currentLevel + 3;
                SceneManager.LoadScene(1);
            }*/
        }
    }
}
