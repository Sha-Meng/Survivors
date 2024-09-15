using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单发射击口
/// </summary>
public class SingleFirePoint : IFirePoint
{
    private bool mEnable = false;
    private int mBulletId;
    // 射击频率
    private float mInterval = 1f / 5;
    private float mDelta = 0f;
    private GameObject mFirePointObj = null;
    private Transform mParent;

    public Vector3 Forward
    {
        get
        {
            return mFirePointObj.transform.forward;
        }
    }

    public void Init(Transform parent, Vector3 offset)
    {
        mFirePointObj = new GameObject("FirePoint");
        mFirePointObj.transform.parent = parent;
        mFirePointObj.transform.localPosition += offset;
        mParent = parent;
    }

    public void Fire(int bulletId)
    {
        mBulletId = bulletId;
        mEnable = true;
    }

    public void StopFire()
    {
        mEnable = false;
    }

    public void Update(float deltaTime)
    {
        if (!mEnable)
            return;

        mFirePointObj.transform.RotateAround(mParent.transform.position, mParent.transform.up, 60 * deltaTime);
        mDelta += deltaTime;
        if (mDelta >= mInterval)
        {
            mDelta = 0f;
            FireOnce();
        }
    }

    private void FireOnce()
    {
        // 触发一次发射
        SingletonGameCore.GetInstance().WeaponMdl
            .CreateBullet(mBulletId, mFirePointObj.transform.position, mFirePointObj.transform.forward);

    }
}
