using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldManager : MonoBehaviour
{
    public List<GameObject> Allies;
    public List<GameObject> Enemies;

    public GameObject ally;
    public GameObject enemy;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("PlayerObject").transform;

        //for (int i = 0; i < 10; i++)
        //{
        //    Vector2 randomPos = Random.insideUnitCircle;
        //    Vector3 randomPos3d = new Vector3(randomPos.x+player.position.x, player.position.y + 10, randomPos.y+player.position.z);
        //    Allies.Add(Instantiate(enemy, randomPos3d, Random.rotation));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
