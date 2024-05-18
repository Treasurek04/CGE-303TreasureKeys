using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFlyingChase : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public float speed = 2f;
    public float chaseRange = 3f;

    public enum EnemyState { Patrolling, Chasing };
    public EnemyState currentState = EnemyState.Patrolling;

    private GameObject target;
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int currentPatrolPointIndex = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found. Ensure there is a GameObject with the 'Player' tag in the scene.");
        }

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("No patrol points assigned!");
        }
        else
        {
            target = patrolPoints[currentPatrolPointIndex];
        }
    }

    void Update()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            return; // No patrol points to work with
        }

        UpdateState();

        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                break;
            case EnemyState.Chasing:
                ChasePlayer();
                break;
        }

        if (target != null)
        {
            Debug.DrawLine(transform.position, target.transform.position, Color.red);
        }
    }

    void UpdateState()
    {
        if (IsPlayerInChaseRange() && currentState == EnemyState.Patrolling)
        {
            currentState = EnemyState.Chasing;
        }
        else if (!IsPlayerInChaseRange() && currentState == EnemyState.Chasing)
        {
            currentState = EnemyState.Patrolling;
        }
    }

    bool IsPlayerInChaseRange()
    {
        if (player == null)
        {
            return false;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= chaseRange;
    }

    void Patrol()
    {
        if (target == null)
        {
            return; // No target to move towards
        }

        if (Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            target = patrolPoints[currentPatrolPointIndex];
        }
        MoveTowardsTarget();
    }

    void ChasePlayer()
    {
        if (player == null)
        {
            return; // No player to chase
        }

        target = player;
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (target == null)
        {
            return; // No target to move towards
        }

        Vector2 direction = (Vector2)(target.transform.position - transform.position);
        direction.Normalize();
        rb.velocity = direction * speed;
        FaceForward(direction);
    }

    private void FaceForward(Vector2 direction)
    {
        if (direction.x < 0)
        {
            sr.flipX = false;
        }
        else if (direction.x > 0)
        {
            sr.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (patrolPoints != null)
        {
            Gizmos.color = Color.green;
            foreach (GameObject point in patrolPoints)
            {
                if (point != null)
                {
                    Gizmos.DrawWireSphere(point.transform.position, 0.5f);
                }
            }
        }
    }
}
