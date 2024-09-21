using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProp : IProp
{
    private Transform mRoot;
    public Transform Root
    {
        get { return mRoot; }
    }

    public void Init(int propId)
    {
        mRoot = new GameObject("LaserProp").transform;
        string path = String.Format("Props/Prop_LaserProp{0}", propId);
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab != null)
        {
            GameObject propObj = GameObject.Instantiate(prefab);
            if (propObj != null)
            {
                propObj.transform.parent = mRoot;
                PropMono mono = propObj.AddComponent<PropMono>();
                mono.Init(this);
            }
        }
        else
        {
            Debug.LogError($"[Prop] Load Prop {path} Fail!");
        }
    }

    public void OnHit(IActor actor)
    {
        // 命中敌人
        // 播放命中效果
        
    }

    public void SetParent(Transform parent, Vector3 offset)
    {
        mRoot.parent = parent;
        var transform = mRoot.transform;
        transform.localPosition = offset;
        transform.localRotation = parent.localRotation;
    }
}
