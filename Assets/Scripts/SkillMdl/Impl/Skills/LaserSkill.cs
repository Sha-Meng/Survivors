using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSkill : ILaserSkill
{
    private IActor mOwner;
    private IProp mProp;
    
    public void Init(IActor actor, int propId)
    {
        mOwner = actor;
        mProp = SingletonGameCore.GetInstance().PropsMdl.CreateProp(PropType.Laser, propId);
        mProp.SetParent(actor.Root, Vector3.up);
    }

    public void Update(float deltaTime)
    {
        Rotate(30 * deltaTime);
    }

    public void Rotate(float angle)
    {
        mProp.Root.RotateAround(mOwner.Position, Vector3.up, angle);
    }
}
