using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseObjects;
    void Start()
    {
        unPause();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the esc button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                unPause();
            }
        }
    }

    public void pause()
    {
        pauseObjects.SetActive(true);
        Time.timeScale = 0;
        //unlock the cursor which was locked when entering first person
        Cursor.lockState = CursorLockMode.None;
    }

    public void unPause()
    {   
        pauseObjects.SetActive(false);
        Time.timeScale = 1;
        //relock the cursor for first person activities
        Cursor.lockState = CursorLockMode.Locked;
    }
}
