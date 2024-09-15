using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    GameObject Root { get; }
    bool Enable { get; }

    // 初始化位置和速度
    void Init(int bulletId, Vector3 pos, Vector3 velocity);
    void Update(float deltaTime);

    void Recycle();
}
