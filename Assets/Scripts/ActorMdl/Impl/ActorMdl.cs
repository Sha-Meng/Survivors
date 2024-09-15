using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMdl : IActorMdl
{
    private IActor mMainActor;
    private List<IActor> mActorList = new List<IActor>();
    private EnemyActorMgr mEnemyActorMgr;

    public void Init()
    {
        mActorList = new List<IActor>();
        mMainActor = CreateActor(ActorType.RealPlayer, Vector3.zero, Quaternion.identity);
        mMainActor.SetVelocity(Vector3.forward);
        mEnemyActorMgr = new EnemyActorMgr();
        mEnemyActorMgr.Init();
    }

    public void Update(float deltaTime)
    {
        foreach (var actor in mActorList)
        {
            actor.Update(deltaTime);
        }
        
        mEnemyActorMgr.Update(deltaTime);
    }

    public IActor CreateActor(ActorType actorType, Vector3 localPosition, Quaternion localRotation)
    {
        IActor actor = new Actor();
        actor.Init(actorType);
        actor.SetLocalPosition(localPosition);
        actor.SetRotation(localRotation);
        mActorList.Add(actor);

        return actor;
    }

    public void RemoveActor(IActor actor)
    {
        actor.Recycle();
        mActorList.Remove(actor);
    }

    public IActor MainActor
    {
        get { return mMainActor; }
    }
    
    
}
