using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMdl : IWeaponMdl
{
    private BulletMgr mBulletMgr;
    
    public void Init()
    {
        mBulletMgr = new BulletMgr();
    }

    public void Update(float deltaTime)
    {
        mBulletMgr.Update(deltaTime);
    }

    public IFirePoint CreateFirePoint(FirePointType type, Transform parent, Vector3 offset)
    {
        IFirePoint firePoint = null;
        if (type == FirePointType.SingleFirePoint)
        {
            firePoint = new SingleFirePoint();
            
        }
        
        firePoint?.Init(parent, offset); 
        return firePoint;
    }

    public IBullet CreateBullet(int bulletId, Vector3 pos, Vector3 velocity)
    {
        return mBulletMgr.CreateBullet(bulletId, pos, velocity);
    }
    
    
}
