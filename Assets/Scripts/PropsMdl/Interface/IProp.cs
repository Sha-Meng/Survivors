using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProp
{
    Transform Root { get; }
    void Init(int propId);

    void OnHit(IActor actor);

    void SetParent(Transform parent, Vector3 offset);
}
