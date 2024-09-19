using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMono : MonoBehaviour
{
    public IProp Prop;

    public void Init(IProp prop)
    {
        Prop = prop;
    }
}
