using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputMode : IInputMode
{
    private IActor mMainActor = null;
    public void Init()
    {
        mMainActor = SingletonGameCore.GetInstance().ActorMdl.MainActor;
    }

    public void Update(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            mMainActor.AddSpeed(1f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            mMainActor.Rotate(-10f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            mMainActor.AddSpeed(-1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            mMainActor.Rotate(10f);
        }
    }
}
