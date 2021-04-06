using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth = 4;

    public HealthBar healthBar = null;
    private BattlefieldManager battle;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        battle = GameObject.Find("Battlefield").GetComponent<BattlefieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(1);
        //}

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Taking damage");

        if (currentHealth <= 0)
        {
            if(transform.parent.gameObject.name == "MeleeAlly(Clone)")
            {
                battle.RemoveAllyMelee(transform.parent.gameObject);
            }
            if (transform.parent.gameObject.name == "MeleeEnemy(Clone)")
            {
                battle.RemoveEnemyMelee(transform.parent.gameObject);
            }
            if (transform.parent.gameObject.name == "GunAlly(Clone)")
            {
                battle.RemoveAllyRange(transform.parent.gameObject);
            }
            if (transform.parent.gameObject.name == "GunEnemy(Clone)")
            {
                battle.RemoveEnemyRange(transform.parent.gameObject);
            }
        }
    }


}
