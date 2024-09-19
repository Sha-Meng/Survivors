using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 护盾技能
public class ShieldSkill : IShieldSkill
{
    private IActor mOwner;
    private IProp mProp;
    
    public void Init(IActor actor, int propId)
    {
        mOwner = actor;
        mProp = SingletonGameCore.GetInstance().PropsMdl.CreateProp(PropType.Shield, propId);
        mProp.SetParent(actor.Root, Vector3.up + actor.Root.forward * 3);
    }

    public void Update(float deltaTime)
    {
        mProp.Root.RotateAround(mOwner.Position, Vector3.up, 90 * deltaTime);
    }

    public void Rotate(float angle)
    {
        mProp.Root.RotateAround(mOwner.Position, Vector3.up, angle);
    }
}
