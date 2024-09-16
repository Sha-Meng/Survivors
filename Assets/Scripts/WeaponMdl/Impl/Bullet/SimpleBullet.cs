using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BulletBase, IBullet
{
    public override void Init(int bulletId, Vector3 pos, Vector3 dir)
    {
        base.Init(bulletId, pos, dir);
        
        BulletMono mono = mBulletObj.AddComponent<BulletMono>();
        mono.Init(this);
    }

    protected override void OnBulletDisappear()
    {
        if (mBulletParam.EffectType == BulletEffectType.SplitBullet)
        {
            // 分裂
            IWeaponMdl weaponMdl = SingletonGameCore.GetInstance().WeaponMdl;
            Vector3 pos = mBulletObj.transform.position;
            Vector3 dir = mBulletObj.transform.forward;

            for (int i = 0, count = mBulletParam.SplitAngleList.Length; i < count; i++)
            {
                Quaternion rotation = Quaternion.AngleAxis(mBulletParam.SplitAngleList[i], Vector3.up);
                Vector3 targetDir = rotation * dir;
                weaponMdl.CreateBullet(mBulletParam.SplitBulletId, pos, targetDir);
            }
        }
    }
}
