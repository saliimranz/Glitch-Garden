using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, Damage; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attackers attacker = collision.gameObject.GetComponent<Attackers>();
        Health health = collision.gameObject.GetComponent<Health>();

        if(attacker && health)
        {
            health.dealDamage(Damage);
            Destroy(gameObject);
        }
    }

}
