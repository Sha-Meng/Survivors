using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    GameObject Root { get; }
    bool Enable { get; }

    // 初始化位置和速度
    void Init(int bulletId, Vector3 pos, Vector3 dir);
    void Update(float deltaTime);

    // 命中角色
    void OnHit(IActor actor);

    void Recycle();
}
