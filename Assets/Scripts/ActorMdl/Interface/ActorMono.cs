using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMono : MonoBehaviour
{
    public IActor Actor;

    public void Init(IActor actor)
    {
        Actor = actor;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Actor.ActorType == ActorType.RealPlayer)
        {
            // 自己：检测敌人
            ActorMono actorMono = other.gameObject.GetComponent<ActorMono>();
            if (actorMono != null)
            {
                // 被敌人撞到
                // TO: 扣血
                // 敌人销毁
                SingletonGameCore.GetInstance().ActorMdl.RemoveActor(actorMono.Actor);
            }
        }
        else if (Actor.ActorType == ActorType.EnemyPlayer)
        {
            // 敌人：检测子弹
            BulletMono bulletMono = other.gameObject.GetComponent<BulletMono>();
            if (bulletMono != null)
            {
                // 被子弹打中了, 自己被销毁
                SingletonGameCore.GetInstance().ActorMdl.RemoveActor(Actor);
                bulletMono.Bullet.OnHit(Actor);
            }
        }
    }
}
