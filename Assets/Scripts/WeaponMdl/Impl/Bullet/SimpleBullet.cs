using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : IBullet
{
    private Vector3 mVelocity;
    private GameObject mBulletObj;

    private float mInterval = 5f;
    private float mDelta = 0f;
    
    private bool mEnable = true;
    public bool Enable
    {
        get { return mEnable; }
    }

    public GameObject Root
    {
        get { return mBulletObj; }
    }

    public void Init(int bulletId, Vector3 pos, Vector3 velocity)
    {
        string path = string.Format("Weapon/Bullet/bullet_{0}", bulletId);
        GameObject prefab = Resources.Load<GameObject>(path);
        mBulletObj = GameObject.Instantiate(prefab);
        mBulletObj.transform.position = pos;
        BulletMono mono = mBulletObj.AddComponent<BulletMono>();
        mono.Init(this);
        mVelocity = velocity;
        mDelta = 0f;
    }

    public void Update(float deltaTime)
    {
        if (!mEnable)
            return;
        
        mDelta += deltaTime;
        // 到时间销毁
        if (mDelta >= mInterval)
        {
            mEnable = false;
            return;
        }
        mBulletObj.transform.position += mVelocity * deltaTime;
    }

    public void Recycle()
    {
        // TODO : 子弹池子管理起来
        GameObject.Destroy(mBulletObj);
    }
}
