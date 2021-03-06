using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{
    public ParticleSystem [] waves;
    public float [] timeRemaining;
    public float[] initialTime;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            //if waves are not playing
            if (!waves[i].isPlaying)
            {
                //start a timer until they start again
                if (timeRemaining[i] > 0)
                {
                    timeRemaining[i] -= Time.deltaTime;
                }
                //timer runs out play it
                else
                {
                    waves[i].Play();
                    timeRemaining[i] = initialTime[i];
                }
            }


        }
    }
}
