using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BulletManager : MonoBehaviour
{
    public void BulletInstantiate(GameObject bullet, Weapon wp, GameObject player)
    {
        var b = bullet.GetComponent<Bullet>();
        b.BulletInitialize(wp, player);
        var aci = b.angle;
        for (int i = 0; i < b.bulletCount; i++)
        {
            b.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - wp.weaponObject.transform.position;
            b.direction.z = 0f;
            b.direction.Normalize();

            b.directionToAngle = Vector3.Angle(b.direction, Vector3.up);
            if (b.direction.x < 0)
            {
                b.directionToAngle = 360 - b.directionToAngle;
            }


            if (b.directionToAngle >= b.angleRange / 2f)
            {
                b.directionToAngle -= b.angleRange / 2f;
            }
            else
            {
                b.directionToAngle = 360 - (b.angleRange / 2f - b.directionToAngle);
            }
            b.directionToAngle += aci;
            var currentBullet = Instantiate(bullet, GameObject.Find("BulletPoint").transform.position, Quaternion.Euler(new Vector3(0, 0, b.directionToAngle - (b.directionToAngle * 2))));
            float angleRadians = b.directionToAngle * Mathf.Deg2Rad;
            float y = Mathf.Cos(angleRadians);
            float x = Mathf.Sin(angleRadians);

            b.direction = new Vector3(x, y, 0f);

            aci += b.angle;
            currentBullet.GetComponent<Rigidbody2D>().velocity = b.direction * b.speed;
            Destroy(currentBullet, b.range / b.speed);
        }
    }
}
