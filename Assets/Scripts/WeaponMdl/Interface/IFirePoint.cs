using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射击口
/// </summary>
public interface IFirePoint
{
    Vector3 Forward { get; }

    void Init(Transform parent, Vector3 offset);
    void Fire(int bulletId);

    void StopFire();

    void Update(float deltaTime);
}
