using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        SingletonGameCore.GetInstance().Init();
    }

    private void Update()
    {
        SingletonGameCore.GetInstance().Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        SingletonGameCore.GetInstance().LateUpdate();
    }
}
