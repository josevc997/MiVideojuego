using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator Animator;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        Animator = GetComponent<Animator>();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            enemy.healthPoints -= 2f;
            if (enemy.healthPoints <= 0)
            {
                //Destroy(gameObject);
                Animator.SetBool("grounded", true);
                
            }
            /*else
            {
                //Animator.SetBool("grounded", false);
            }*/
        }
    }

}
