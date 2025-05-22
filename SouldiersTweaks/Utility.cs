using System.Collections.Generic;
using UnityEngine;

namespace SouldiersTweaks
{
    public class Utility
    {
        public static DifficultyManager.DifficultyLevel GetDifficultyLevel()
        {
            List<DifficultyManager.DifficultyLevel> difficultyLevels = DifficultyManager.s_cInstance.GetDifficultyLevels();

            for (int i = 0; i < difficultyLevels.Count; i++)
            {
                if (difficultyLevels[i].m_level == DifficultyManager.s_cInstance.m_currentDifficulty)
                {
                    return difficultyLevels[i];
                }
            }

            return null;
        }

        public static PlayMakerFSM GetPlayerFsm()
        {
            var player = GameObject.FindGameObjectsWithTag("Player");

            if (player.Length > 0)
            {
                PlayMakerFSM fsm = player[0].GetComponent(typeof(PlayMakerFSM)) as PlayMakerFSM;

                if (fsm != null)
                {
                    return fsm;
                }
            }

            return null;
        }

        public static Constants.eCharacters GetPlayerType()
        {
            var playerCurrentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            var baseStats = (PlayerBaseStats) playerCurrentStats.GetBaseStats();
            var characterType = baseStats.characterType;

            return characterType;
        }

        public static bool IsPlayerArcher()
        {
            return GetPlayerType() == Constants.eCharacters.ARCHER;
        }

        public static bool IsPlayerWizard()
        {
            return GetPlayerType() == Constants.eCharacters.WIZARD;
        }

        public static bool IsPlayerSoldier()
        {
            return GetPlayerType() == Constants.eCharacters.SOLDIER;
        }

        public static PlayerCurrentStats GetPlayerCurrentStats()
        {
            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();

            if (IsPlayerArcher())
            {
                return currentStats as ArcherCurrentStats;
            }

            if (IsPlayerWizard())
            {
                return currentStats as WizardCurrentStats;
            }

            if (IsPlayerSoldier())
            {
                return currentStats as SoldierCurrentStats;
            }

            return currentStats;
        }
    }
}
