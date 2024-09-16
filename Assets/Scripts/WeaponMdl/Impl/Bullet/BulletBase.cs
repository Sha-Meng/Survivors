using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase 
{
    protected Vector3 mVelocity;
    protected GameObject mBulletObj;
    protected BulletParam mBulletParam;

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

    public virtual void Init(int bulletId, Vector3 pos, Vector3 dir)
    {
        string path = string.Format("Weapon/Bullet/bullet_{0}", bulletId);
        GameObject prefab = Resources.Load<GameObject>(path);
        mBulletObj = GameObject.Instantiate(prefab);
        if (mBulletObj == null)
        {
            Debug.LogError($"子弹模型缺失:{path}");
        }
        mBulletObj.transform.position = pos;
        mBulletObj.transform.rotation = Quaternion.LookRotation(dir);

        mDelta = 0f;
        string paramPath = string.Format("Weapon/Bullet/bulletParam_{0}", bulletId);
        GameObject paramPrefab = Resources.Load<GameObject>(paramPath);
        GameObject paramObj = GameObject.Instantiate(paramPrefab);
        if (paramObj == null)
        {
            Debug.LogError($"子弹参数缺失:{paramPath}");
            return;
        }
        mBulletParam = paramObj.GetComponent<BulletParam>();
        if (mBulletParam == null)
        {
            Debug.LogError($"子弹参数异常:{paramPath}");
            return;
        }
        mInterval = mBulletParam.FlyTime;
        mVelocity = dir * mBulletParam.Speed;
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
            OnBulletDisappear();
            return;
        }
        mBulletObj.transform.position += mVelocity * deltaTime;
    }

    // 子弹到最远飞行距离了
    protected virtual void OnBulletDisappear()
    {
        
    }

    public void OnHit(IActor actor)
    {
        // 命中敌人
        // 播放命中效果
        if (!string.IsNullOrEmpty(mBulletParam.HitEffectPath))
        {
            GameObject prefab = Resources.Load<GameObject>(mBulletParam.HitEffectPath);
            GameObject obj = GameObject.Instantiate(prefab, actor.Position, actor.Rotation);
            GameObject.Destroy(obj, 5f);
        }
        
    }

    public void Recycle()
    {
        // TODO : 子弹池子管理起来
        GameObject.Destroy(mBulletObj);
    }
}
