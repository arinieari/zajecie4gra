using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, startingHealth);
         if (CurrentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
         else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<playermovement>().enabled = false;
                dead = true;
            }
            
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
