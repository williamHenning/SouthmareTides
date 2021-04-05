using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunnerAI : MonoBehaviour
{
    [SerializeField]
    private AIMovement movement;

    [SerializeField]
    private BattlefieldManager battle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestAlly = null;
        float minDist = float.MaxValue;
        // find the closest ally
        foreach(GameObject ally in battle.Allies)
        {
            float dist = Vector3.Distance(transform.position, ally.transform.position);
            if(dist < minDist)
            {
                minDist = dist;
                closestAlly = ally;
            }
        }
        Vector3 vec = (closestAlly.transform.position - transform.position).normalized;
        // move towards them
        movement.HandleMovement(closestAlly.transform.position, false);
        // attack if close enough
    }
}
