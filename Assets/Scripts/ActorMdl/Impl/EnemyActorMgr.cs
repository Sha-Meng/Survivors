using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyActorMgr
{
    private IActorMdl mActorMdl;

    private float mRefreshEnemyInterval = 5f;
    private float mRefreshEnemyDelta = 0;

    private float mEnemySpeed = 0.1f;
    private float mRandomBirthCircleMin = 10f;
    private float mRandomBirthCircleMax = 20f;
    public void Init()
    {
        mActorMdl = SingletonGameCore.GetInstance().ActorMdl;
    }
    
    public void Update(float deltaTime)
    {
        mRefreshEnemyDelta += deltaTime;
        if (mRefreshEnemyDelta >= mRefreshEnemyInterval)
        {
            mRefreshEnemyDelta = 0;
            CreateRandomBirthPoint(out Vector3 position, out Vector3 direction);
            IActor actor = mActorMdl.CreateActor(ActorType.EnemyPlayer, position, Quaternion.LookRotation(direction));
            actor.SetVelocity(direction * mEnemySpeed);
        }
    }

    private void CreateRandomBirthPoint(out Vector3 position, out Vector3 direction)
    {
        Vector3 mainActorPosition = mActorMdl.MainActor.Position;

        float r = Random.Range(mRandomBirthCircleMin, mRandomBirthCircleMax);
        float theta = (float)(Random.Range(0f, 360f) / 180f * Math.PI);
        position = new Vector3(r * (float)Math.Cos(theta), mainActorPosition.y, r * (float)Math.Sin(theta));
        direction = mainActorPosition - position;
    }
}
