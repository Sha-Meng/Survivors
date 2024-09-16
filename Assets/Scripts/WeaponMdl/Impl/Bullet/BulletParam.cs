using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParam : MonoBehaviour
{
    [Header("飞行时长")]
    public float FlyTime = 5f;
    [Header("飞行速度")]
    public float Speed = 1.5f;
    [Header("伤害")] 
    public float Damage = 1f;
    [Header("命中特效路径")]
    public string HitEffectPath;
    [Header("子弹效果")]
    public BulletEffectType EffectType;
    [Header("分裂弹")]
    public int SplitBulletId;
    [Header("分裂角度")]
    public float[] SplitAngleList;
}

public enum BulletEffectType
{
    None,
    SplitBullet, // 分裂
}
