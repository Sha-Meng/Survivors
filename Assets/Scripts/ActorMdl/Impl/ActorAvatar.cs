using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAvatar
{
    public GameObject mAvatarObj;
    private IActor mActor;
    private Animator mAnimator;
    public void Init(IActor actor)
    {
        string path = LoadAvatarPath(actor.ActorType);
        GameObject prefab = Resources.Load<GameObject>(path);
        mAvatarObj = GameObject.Instantiate(prefab);
        mAnimator = mAvatarObj.GetComponent<Animator>();
        mActor = actor;
        
        ActorMono mono = mAvatarObj.AddComponent<ActorMono>();
        mono.Init(actor);
    }

    private string LoadAvatarPath(ActorType actorType)
    {
        string path = string.Format("Avatar/Prefab/{0}", actorType.ToString());
        return path;
    }

    public void Recycle()
    {
        GameObject.Destroy(mAvatarObj);
    }
    
    public void Update(float deltaTime)
    {
        mAvatarObj.transform.localPosition = mActor.Position;
        mAvatarObj.transform.localRotation = mActor.Rotation;
        mAnimator.SetFloat("Speed", mActor.Speed);
        // 方向
        // float dotValue = Vector3.Dot(mActor.Velocity.normalized, mAvatarObj.transform.forward);
        // mAnimator.SetFloat("Dir", dotValue);
    }
}
