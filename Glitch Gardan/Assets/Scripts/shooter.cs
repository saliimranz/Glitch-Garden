using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject projectile, Gun;
    public GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        //creates a parent if necessary
        if (!projectileParent)
        {
            projectileParent = new GameObject();
        }
        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Update()
    {
        if (isAttackerAheadinLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Fire()
    {
       GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = Gun.transform.position;
    }

    bool isAttackerAheadinLane()
    {
        //exit if no attacker in lane
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        
        //if there are attackers are they ahead
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        //attackers in lane but behind us
        return false;

    }
    // look through all spawners and set mylanespawner if one found 
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't get the spawner");
    }
}
