using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioSource click;
    public void changeScene(string sceneName)
    {
        click.Play();
        SceneManager.LoadScene(sceneName);
        
    }
}
