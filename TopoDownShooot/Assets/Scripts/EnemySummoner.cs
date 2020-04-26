using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemySummoner : Enemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSummons;
    public Enemy enemyToSummon;
    public float meleeAttackSpeed;
    public float stopDistance;
    
    private Vector2 targetPosition;
    private Animator animator;
    private float summonTime;
    private float timer;

    public override void Start()
    {
        base.Start();

        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);
        
        targetPosition = new Vector2(randomX, randomY);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    animator.SetTrigger("summon");
                }
            }

            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                if (Time.time > timer)
                {
                    timer = Time.time + timeBetweenSummons;
                    StartCoroutine(MeleeAttack());
                }
            }
        }
    }

    public void SummonMinion()
    {
        Instantiate(enemyToSummon, transform.position, transform.rotation);
    }
    
    IEnumerator MeleeAttack()
    {
        player.GetComponent<Player>().TakeDamage(damage);
        
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * meleeAttackSpeed;
            var formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);

            yield return null;
        }
    }
}
