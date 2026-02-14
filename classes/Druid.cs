using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : Character
{
    public int dieType = 8;     // d8
    public int dieAverage = 5;  // real average 4.5

    public Druid(string name, int level, string characterClass, int conScore, string race, bool hasTough, bool hasStout, bool hPAveraged) : base(name, level, characterClass, conScore, race, hasTough, hasStout, hPAveraged)
    {

    }
    public void CalculateHP()
    {
        //GetCharacterClass();
        //GetCharacterRace();

        for (int i = 1; i <= level; i++)
        {
            int tempHP;

            if (hPAveraged)
            {
                tempHP = dieAverage + GetConModifier() + GetRaceBonus() + GetToughBonus() + GetStoutBonus();
                finalHP += tempHP;
            }
            else if (!hPAveraged)
            {
                tempHP = Random.Range(1, dieType + 1) + GetConModifier() + GetRaceBonus() + GetToughBonus() + GetStoutBonus();
                finalHP += tempHP;
            }
        }

        Debug.Log("Name: " + name + ", Final HP: " + finalHP);
    }
}
