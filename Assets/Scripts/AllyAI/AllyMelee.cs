using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMelee : MonoBehaviour
{
    [SerializeField]
    private AIMovement movement;

    [SerializeField]
    private BattlefieldManager battle;

    [SerializeField]
    private float meleeAttackRange = 3.0f;

    public LayerMask playerLayerMask, enemyLayerMask;

    // Attack
    private bool isAttacking = false;
    Animator m_animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;




    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        enemyLayerMask = LayerMask.GetMask("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestEnemy = null;
        float minDist = float.MaxValue;
        // find the closest enemyLayerMask
        foreach (GameObject enemy in battle.Enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closestEnemy = enemy;
            }
        }
        Vector3 vec = (closestEnemy.transform.position - transform.position).normalized;
        // move towards them
        movement.HandleMovement(closestEnemy.transform.position, meleeAttackRange, false);
        // attack if close enough
        bool isPlayerClose = Physics.CheckSphere(transform.position, meleeAttackRange, playerLayerMask);
        bool isEnemyClose = Physics.CheckSphere(transform.position, meleeAttackRange, enemyLayerMask);
        if (isEnemyClose)
        {
            Attack();
        }
        UpdateDamage();

    }

    public void Attack()
    {
        // Attack animation
        m_animator.SetTrigger("Attack");
    }

    public void UpdateDamage()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {

            //enemyStats.TakeDamage(m_Stats.damage.GetValue());
            // TODO: do this with weapon collider
            // weaponCollider.gameObject.
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayerMask);


            if (!isAttacking && hitEnemies.Length > 0)
            if (!isAttacking && hitEnemies.Length > 0)
            {
                hitEnemies[0].GetComponent<CharacterStats>().TakeDamage(1);
                isAttacking = true;

            }

        }

        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
        {
            isAttacking = false;
        }


    }
}
