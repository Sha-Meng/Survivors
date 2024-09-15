using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr
{
    private List<IBullet> mBulletList = new List<IBullet>();
    public IBullet CreateBullet(int bulletId, Vector3 pos, Vector3 velocity)
    {
        IBullet bullet = new SimpleBullet();
        bullet.Init(bulletId, pos, velocity);
        mBulletList.Add(bullet);

        return bullet;
    }

    public void Update(float deltaTime)
    {
        for (int i = mBulletList.Count - 1; i >= 0; i--)
        {
            IBullet bullet = mBulletList[i];
            if (!bullet.Enable)
            {
                bullet.Recycle();
                mBulletList.RemoveAt(i);
            }
            else
            {
                bullet.Update(deltaTime);
            }
        }
    }
}
