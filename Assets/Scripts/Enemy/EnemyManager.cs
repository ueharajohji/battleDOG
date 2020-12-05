using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    //public Collider weaponCollider;
    //public EnemyUIManager enemyUIManager;
    public int maxHp = 100;
    public int maxSp = 100;
    public int hp;
    void Start()
    {
        hp = maxHp;
        Debug.Log("calling init with maxHp" + maxHp);
        //enemyUIManager.Init(this);
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        //DisableWeaponCollider();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }

    void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            animator.SetTrigger("Die");
        }
        //enemyUIManager.UpdateHp(hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager !=null)
        {
            animator.SetTrigger("DamageReceive");
            GetDamage(damager.damage);
        }
    }

    //public void EnableWeaponCollider()
    //{
    //    weaponCollider.enabled = true;
    //}

    //public void DisableWeaponCollider()
    //{
    //    weaponCollider.enabled = false;
    //}
}
