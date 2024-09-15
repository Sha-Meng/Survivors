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


    public void Init()
    {
        mWeaponMdl = new WeaponMdl();
        mWeaponMdl.Init();
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
    }

    public void LateUpdate()
    {
        mCameraMdl.LateUpdate();
    }
}
