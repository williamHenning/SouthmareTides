using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour
{
    [SerializeField]
    private AIMovement movement;

    [SerializeField]
    private BattlefieldManager battle;

    [SerializeField]
    private float meleeAttackRange = 3.0f;

    public LayerMask playerLayerMask, allyLayerMask;

    // Attack
    private bool isAttacking = false;
    Animator m_animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;




    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        allyLayerMask = LayerMask.GetMask("Ally");
        battle = GameObject.Find("Battlefield").GetComponent<BattlefieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestAlly = null;
        float minDist = float.MaxValue;
        // find the closest ally
        foreach (GameObject ally in battle.Allies)
        {
            float dist = Vector3.Distance(transform.position, ally.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closestAlly = ally;
            }
        }
        Vector3 vec = (closestAlly.transform.position - transform.position).normalized;
        // move towards them
        movement.HandleMovement(closestAlly.transform.position, meleeAttackRange, false);
        // attack if close enough
        bool isPlayerClose = Physics.CheckSphere(transform.position, meleeAttackRange, playerLayerMask);
        bool isAllyClose = Physics.CheckSphere(transform.position, meleeAttackRange, allyLayerMask);
        if(isPlayerClose || isAllyClose)
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
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, allyLayerMask);


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
