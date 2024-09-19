using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillMdl
{
    void Init();

    void Update(float deltaTime);

    /// <summary>
    /// 某位玩家释放某个技能
    /// </summary>
    /// <param name="actor"></param>
    /// <param name="skillType"></param>
    /// <returns></returns>
    ISkill CreateSkill(IActor actor, SkillType skillType, int skillId);
}
