using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    public void dealDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            //trigger death animation here.
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        //not destroy "Game Object" but destroy whole thing Health.cs is attached to.
        Destroy(gameObject);
    }
}
