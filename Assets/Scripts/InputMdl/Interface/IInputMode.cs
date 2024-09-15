using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputMode
{
    void Init();
    
    void Update(float deltaTime);
}
