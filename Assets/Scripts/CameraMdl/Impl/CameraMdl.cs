using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMdl : ICameraMdl
{
    private IActor mMainActor;
    private Camera mMainCamera;
    private Vector3 mCameraOffset = new Vector3(0, 7.5f, -14.6f);
    public void Init()
    {
        mMainActor = SingletonGameCore.GetInstance().ActorMdl.MainActor;
        GameObject obj = new GameObject("Main Camera");
        mMainCamera = obj.AddComponent<Camera>();
    }

    public void LateUpdate()
    {
        mMainCamera.transform.position = mMainActor.Position + mCameraOffset;
        mMainCamera.transform.LookAt(mMainActor.Position);
    }
}
