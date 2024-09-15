using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMono : MonoBehaviour
{
    public IBullet Bullet;

    public void Init(IBullet bullet)
    {
        Bullet = bullet;
    }
}
