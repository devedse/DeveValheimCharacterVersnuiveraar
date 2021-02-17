using DeveValheimCharacterVersnuiveraar.GameClasses;
using DeveValheimCharacterVersnuiveraar.GameClasses.Enums;

namespace DeveValheimCharacterVersnuiveraar.ReaderWriters
{
    public static class SkillsReaderWriter
    {
        public static void Save(ZPackage pkg, Skills skills)
        {
            pkg.Write(2);
            pkg.Write(skills.m_skillData.Count);

            foreach (var skill in skills.m_skillData)
            {
                pkg.Write((int)skill.skillType);
                pkg.Write(skill.m_level);
                pkg.Write(skill.m_accumulator);
            }
        }

        // Token: 0x0600026C RID: 620 RVA: 0x000139B0 File Offset: 0x00011BB0
        public static Skills Load(ZPackage pkg)
        {
            var skills = new Skills();

            int num = pkg.ReadInt();
            skills.m_skillData.Clear();
            int num2 = pkg.ReadInt();
            for (int i = 0; i < num2; i++)
            {
                var skillType = (SkillType)pkg.ReadInt();
                float level = pkg.ReadSingle();
                float accumulator = (num >= 2) ? pkg.ReadSingle() : 0f;

                var skill = new Skill();
                skill.skillType = skillType;
                skill.m_level = level;
                skill.m_accumulator = accumulator;
            }

            return skills;
        }
    }
}
