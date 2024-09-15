using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorMdl
{
    /// <summary>
    /// 获取主角玩家
    /// </summary>
    /// <returns></returns>
    IActor MainActor { get; }
    
    void Init();
    void Update(float deltaTime);
    IActor CreateActor(ActorType actorType, Vector3 localPosition, Quaternion localRotation);

    void RemoveActor(IActor actor);
}
