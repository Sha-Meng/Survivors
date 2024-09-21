using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMdl : ISkillMdl
{
    private List<ISkill> mSkillList = new List<ISkill>();

    public void Init()
    {
        
    }

    public void Update(float deltaTime)
    {
        foreach (var skill in mSkillList)
        {
            skill.Update(deltaTime);
        }
    }

    public ISkill CreateSkill(IActor actor, SkillType skillType, int skillId)
    {
        ISkill skill = null;
        switch (skillType)
        {
            case SkillType.Shield:
                skill = new ShieldSkill();
                break;
            case SkillType.Laser:
                skill = new LaserSkill();
                break;
        }

        if (skill != null)
        {
            skill.Init(actor, skillId);
            mSkillList.Add(skill);
        }

        return skill;
    }
}
