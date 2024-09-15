using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponMdl
{
    void Init();

    void Update(float deltaTime);
    
    /// <summary>
    /// 创建一个发射口
    /// </summary>
    /// <returns></returns>
    IFirePoint CreateFirePoint(FirePointType type, Transform parent, Vector3 offset);

    IBullet CreateBullet(int bulletId, Vector3 pos, Vector3 velocity);
}
