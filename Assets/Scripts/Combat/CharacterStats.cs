using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth = 4;

    public HealthBar healthBar = null;

    private BattlefieldManager battlefieldManager;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        battlefieldManager = GameObject.Find("Battlefield").GetComponent<BattlefieldManager>();
        
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
        if(currentHealth <= 0)
        {
           
        }
    }


}
