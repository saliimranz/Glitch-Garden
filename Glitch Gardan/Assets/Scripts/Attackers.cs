using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour
{
    [Tooltip("Average Number of secounds between apperences")]
    public float seenEverySecound;
    private float currentSpeed;
    public GameObject currentTarget;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed*Time.deltaTime );
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }

        print(Button.selectedDefender);
    }

    void setSpeed(float speed) {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
    }

    //Called from animator at time of actual attack
    public void strikeCurrentTarget(float damage)
    {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.dealDamage(damage);
            }
            Debug.Log(name + " Damage Caused: " + damage);
        }
    }
    public void attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
