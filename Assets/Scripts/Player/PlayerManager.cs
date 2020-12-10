using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    public float x, y, ms = 3;
    Animator animator;
    public Collider weaponCollider;
    public PlayerUIManager playerUIManager;
    public int maxHp = 100;
    public int hp;
    bool dead;
    public GameObject gameOverText;
    public Transform target;
 
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        ms = 10;        
        playerUIManager.Init(this);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        DisableWeaponCollider();
    }

    void Update()
    {
        if (dead) return;
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LookAtTarget();
            animator.SetTrigger("Attack");
        }
    }

    void LookAtTarget()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 3f) transform.LookAt(target);
    }

    void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            dead = true;
            animator.SetTrigger("Die");
            rb.velocity = Vector3.zero;
            gameOverText.SetActive(true);
        }
        playerUIManager.UpdateHp(hp);
    }

    private void FixedUpdate()
    {
        if (dead) return;
        Debug.Log("fixed updating");
        Vector3 velocity = new Vector3(x, 0, y) * ms;
        Vector3 direction = transform.position + velocity;
        transform.LookAt(direction);
        rb.velocity = velocity;
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            animator.SetTrigger("DamageReceive");
            GetDamage(damager.damage);
        }
    }

    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
}
