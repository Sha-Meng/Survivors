using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameCore
{
    private static SingletonGameCore mGameCore = new SingletonGameCore();

    private SingletonGameCore() { }

    public static SingletonGameCore GetInstance()
    {
        return mGameCore;
    }
    
    private IInputMode mInputMode;
    
    private IActorMdl mActorMdl;
    public IActorMdl ActorMdl
    {
        get
        {
            return mActorMdl;
        }
    }

    private IWeaponMdl mWeaponMdl;

    public IWeaponMdl WeaponMdl
    {
        get
        {
            return mWeaponMdl;
        }
    }

    private ICameraMdl mCameraMdl;

    private ISkillMdl mSkillMdl;

    public ISkillMdl SkillMdl
    {
        get { return mSkillMdl; }
    }

    private IPropsMdl mPropsMdl;

    public IPropsMdl PropsMdl
    {
        get { return mPropsMdl; }
    }


    public void Init()
    {
        mWeaponMdl = new WeaponMdl();
        mWeaponMdl.Init();
        mSkillMdl = new SkillMdl();
        mSkillMdl.Init();
        mPropsMdl = new PropsMdl();
        mPropsMdl.Init();
        
        mActorMdl = new ActorMdl();
        mActorMdl.Init();
        mInputMode = new KeyBoardInputMode();
        mInputMode.Init();
        mCameraMdl = new CameraMdl();
        mCameraMdl.Init();
    }
    
    public void Update(float deltaTime)
    {
        mInputMode.Update(deltaTime);
        mActorMdl.Update(deltaTime);
        mWeaponMdl.Update(deltaTime);
        mSkillMdl.Update(deltaTime);
    }

    public void LateUpdate()
    {
        mCameraMdl.LateUpdate();
    }
}
