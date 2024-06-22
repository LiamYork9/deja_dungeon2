using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    public string sceneName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            LoadTarget(sceneName);
        }
    }

    public void LoadTarget(string sceneName)
    {
        // Debug.Log("sceneloader");
        
        SceneManager.LoadScene(sceneName);
    }
}
