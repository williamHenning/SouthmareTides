using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class MeleeCombat : MonoBehaviour
{
    CharacterStats m_Stats;
    Animator m_animator;

    Collider weaponCollider;
    public Transform attackPoint;

    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

    private HashSet<Collider> enemiesHit = new HashSet<Collider>();
    private bool isAttacking = false;

    void Start()
    {
        m_Stats = GetComponent<CharacterStats>();
        m_animator = GetComponent<Animator>();
        weaponCollider = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Collider>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && !isAttacking)
        {
            Debug.Log("r");
            Attack();
        }
        UpdateDamage();

    }
    public void UpdateDamage()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("MeleeAttack"))
        {
            isAttacking = true;
            //enemyStats.TakeDamage(m_Stats.damage.GetValue());
            // TODO: do this with weapon collider
            // weaponCollider.gameObject.
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);


            //Debug.Log(attackPoint.position);


            foreach (Collider enemy in hitEnemies)
            {
                if (!enemiesHit.Contains(enemy))
                {
                    Debug.Log("hit " + enemy.name);
                    enemy.GetComponent<CharacterStats>().TakeDamage(1);
                }
                enemiesHit.Add(enemy);
            }

            //if(!isAttacking)
            //{
            //    foreach (Collider enemy in hitEnemies)
            //    {
            //        Debug.Log("hit" + enemy.name);
            //        isAttacking = true;
            //    }

            //}

        }

        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
        {

            enemiesHit.Clear();
            isAttacking = false;

        }


    }

    //public void Attack(CharacterStats enemyStats)
    public void Attack()
    {
        // Attack animation
        m_animator.SetTrigger("Attack");


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
