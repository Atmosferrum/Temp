using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    EnemyCtrl enemyCtrl; //THIS EnemyCtrl Script
    public float viewRadius = 5f; // Enemy view radius
    public float viewAngle = 360f; //Enemy view angle    
    Collider2D[] playerInViewRadius; //Player Collider2D in view radius
    public LayerMask rockMask, enemyMask; //Obstacles Masks

    private void Start()
    {
        enemyCtrl = GetComponent<EnemyCtrl>();
    }

    private void FixedUpdate()
    {
        FindPlayer();
    }

    /// <summary>
    ///FIND Player using Field Of View (Physics2D.Raycast)
    /// </summary>
    void FindPlayer()
    {

        if (!GM.Instance.playerCtrl.sneak)
        {
            playerInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, enemyMask);

            for (int i = 0; i < playerInViewRadius.Length; i++)
            {
                if(playerInViewRadius[i] != this)
                {
                    Transform enemy = playerInViewRadius[i].transform;
                    Vector2 dirToEnemy = new Vector2(enemy.position.x - transform.position.x, enemy.position.y - transform.position.y);

                    float distToEnemy = Vector2.Distance(transform.position, enemy.position);

                    if (!Physics2D.Raycast(transform.position, dirToEnemy, distToEnemy, rockMask))
                    {
                        if (!enemyCtrl.chase)
                            if (enemyCtrl.canMove)
                                if (playerInViewRadius[i].GetComponent<EnemyCtrl>().chase)
                                    enemyCtrl.Chase();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Show FOV in Editor
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
