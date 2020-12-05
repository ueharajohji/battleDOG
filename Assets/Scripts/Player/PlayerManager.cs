using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    public float x, y, ms = 3;
    Animator animator;
    //public Collider weaponCollider;
    public PlayerUIManager playerUIManager;
    public int maxHp = 100;
    public int hp;
 
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        //playerUIManager.Init(this);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //DisableWeaponCollider();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            animator.SetTrigger("Die");
        }
        playerUIManager.UpdateHp(hp);
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(x, 0, y) * ms;
        Vector3 direction = transform.position + velocity;
        transform.LookAt(direction);
        rb.velocity = velocity;
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
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
