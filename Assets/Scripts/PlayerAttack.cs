using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    public Animator anim;
    public PlayerMovement pm;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake() {
        pm = GetComponent<PlayerMovement>();

    }
    private void Update() {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown){
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack() {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
