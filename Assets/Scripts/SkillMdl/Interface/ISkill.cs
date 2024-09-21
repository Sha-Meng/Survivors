using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    /// <summary>
    /// 初始化技能
    /// </summary>
    /// <param name="actor"> 技能拥有者 </param>
    void Init(IActor actor, int propId);
    void Update(float deltaTime);
}

// 技能类型
public enum SkillType
{
    Shield, // 护盾
    Laser, // 激光
}
