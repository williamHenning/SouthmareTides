using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyGunner : MonoBehaviour
{
    [SerializeField]
    private AIMovement movement;

    [SerializeField]
    private BattlefieldManager battle;

    [SerializeField]
    private EnemyShoot1 shoot;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private float shootDist = 20.0f;

    [SerializeField]
    private float shootTimer = 15.0f;
    private float shootCD = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        battle = GameObject.Find("Battlefield").GetComponent<BattlefieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestEnemy = null;
        float minDist = float.MaxValue;
        // find the closest ally
        foreach (GameObject enemy in battle.Enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closestEnemy = enemy;
            }
        }
        // move towards them
        movement.HandleMovement(closestEnemy.transform.position, shootDist, false);

        gun.transform.LookAt(closestEnemy.transform.position + new Vector3(0f, 2f, 0f));

        // attack if close enough
        if (Vector3.Distance(closestEnemy.transform.position, transform.position) <= shootDist)
        {
            if (shootCD <= 0.0f)
            {
                shoot.Shoot();
                shootCD += shootTimer;
            }
            shootCD -= Time.deltaTime;
        }
    }
}
