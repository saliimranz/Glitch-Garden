using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class Fox : MonoBehaviour
{
    private Animator anim;
    private Attackers attacker;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attackers>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        
        //Leave the method if not colliding with defender
        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
       {
            anim.SetTrigger("Jump");
        }
        else {
            anim.SetBool("isAttacking", true);
            attacker.attack(obj);
        }
        Debug.Log("Fox collided with " + collision);
    }
}
