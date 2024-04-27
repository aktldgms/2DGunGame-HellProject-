using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    [SerializeField]
    private Canvas cv;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        cv.transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, cv.transform.position.z);
    }
}
