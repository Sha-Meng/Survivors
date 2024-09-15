using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Assertions;

public class Actor : IActor
{
    private IActorMdl mActorMdl;
    private ActorAvatar mActorAvatar;

    private List<IFirePoint> mFirePointList = new List<IFirePoint>();

    private Vector3 mPosition;
    public Vector3 Position
    {
        get { return mPosition; }
    }

    private Quaternion mRotation;
    public Quaternion Rotation
    {
        get { return mRotation; }
    }

    private float mSpeed;
    public float Speed
    {
        get { return mSpeed; }
    }

    // 速度方向
    private Vector3 mVelocityDir;

    private ActorType mActorType;
    public ActorType ActorType
    {
        get { return mActorType; }
    }
    
    public void Init(ActorType actorType)
    {
        mActorMdl = SingletonGameCore.GetInstance().ActorMdl;
        if (mActorAvatar == null)
        {
            mActorAvatar = new ActorAvatar();
        }
        mActorAvatar.Init(this);
        mActorType = actorType;
        if (actorType == ActorType.RealPlayer)
        {
            InitFirePoints();
        }
    }

    public void Recycle()
    {
        mActorAvatar.Recycle();
    }

    public void SetLocalPosition(Vector3 localPosition)
    {
        mPosition = localPosition;
    }

    public void SetRotation(Quaternion rotation)
    {
        mRotation = rotation;
    }

    // 初始化射击口
    private void InitFirePoints()
    {
        mFirePointList.Clear();
        // Test
        Transform avatarTransform = mActorAvatar.mAvatarObj.transform;
        Vector3 offset = avatarTransform.up + avatarTransform.forward;
        IFirePoint firePoint = SingletonGameCore.GetInstance().WeaponMdl.CreateFirePoint(FirePointType.SingleFirePoint, avatarTransform, offset);
        firePoint.Fire(1001);
        mFirePointList.Add(firePoint);
    }

    public void SetVelocity(Vector3 velocity)
    {
        mSpeed = velocity.magnitude;
        if (mSpeed != 0)
        {
            mVelocityDir = velocity.normalized;
        }
    }

    public void AddSpeed(float deltaVel)
    {
        mSpeed += deltaVel;
    }

    public void Rotate(float deltaAngle)
    {
        Quaternion rotation = Quaternion.AngleAxis(deltaAngle, Vector3.up);
        mVelocityDir = rotation * mVelocityDir;
        Debug.LogError(Quaternion.LookRotation(mVelocityDir).eulerAngles.ToString());
    }

    public void Update(float deltaTime)
    {
        UpdateActorRotation(deltaTime);
        mPosition += mVelocityDir * mSpeed * deltaTime;
        mActorAvatar.Update(deltaTime);
        
        foreach (var firePoint in mFirePointList)
        {
            firePoint.Update(Time.deltaTime);
        }
    }
    
    // 控制角色旋转：追赶速度方向
    private void UpdateActorRotation(float deltaTime)
    {
        if (mActorType == ActorType.EnemyPlayer)
        {
            // 敌人自动朝向主角移动
            Vector3 targetPos = mActorMdl.MainActor.Position;
            // 控制朝向
            mRotation = Quaternion.LookRotation(targetPos - Position);
        }
        else if (mActorType == ActorType.RealPlayer)
        {
            // 自己的角度过渡一下
            if (Vector3.Angle(mRotation * Vector3.forward, mVelocityDir) < 1)
            {
                // 角度小于1度  直接置角度
                mRotation = Quaternion.LookRotation(mVelocityDir);
            }
            else
            {
                // 计算方向向量和当前速度向量夹角
                Quaternion rotation = Quaternion.RotateTowards(mRotation, Quaternion.LookRotation(mVelocityDir), 15f * deltaTime);
                // 更新速度方向
                mRotation = rotation;
            }
        }
    }
}
