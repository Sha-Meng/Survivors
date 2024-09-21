using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsMdl : IPropsMdl
{
    public void Init()
    {
        
    }

    public IProp CreateProp(PropType propType, int propId)
    {
        IProp prop = null;
        switch (propType)
        {
            case PropType.Shield:
                prop = new ShieldProp();
                break;
            case PropType.Laser:
                prop = new LaserProp();
                break;
        }

        if (prop != null)
        {
            prop.Init(propId);
        }

        return prop;
    }
}
