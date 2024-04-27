using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public int damage;
    public float speed;
    public float range;
    public int bulletCount;
    public Vector3 direction;
    public float angle;
    public float angleRange;
    public float directionToAngle;
    public void BulletInitialize(Weapon wp, GameObject player)
    {
        damage = wp.damage;
        speed = wp.speed;
        range = wp.range;
        bulletCount = wp.bulletCount;
        angleRange = 45f;
        angle = angleRange / (bulletCount + 1);
        this.player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player") && !collision.CompareTag("Weapon") && !collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Player") && collision.gameObject != player)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
