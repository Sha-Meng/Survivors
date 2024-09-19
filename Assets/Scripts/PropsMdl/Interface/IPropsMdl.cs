using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPropsMdl
{
    void Init();
    IProp CreateProp(PropType propType, int propId);
}

public enum PropType
{
    Shield, // 护盾道具
}
