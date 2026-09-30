using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class CharacterData
{
    public string Name;
    public string Job;
    public string HP;
    public string MaxHP;
    public string Def;
    public string MDef;
    public string Atk;
    public string ASpd;
    public string Mp;
    public string CSpd;
    public string Spd;
    public string Lv;
    public string Exp;
    public string Luck;
    public string CriRate;
    public string CriDmg;
    public string Stamina;
    public string MaxStamina;
    public string Mana;
    public string MaxMana;
    public string Titel;
    public string Money;
    public string Reputation;
    public string Karma;
    public string Hornor;
    public string Team;
    public string HpRegen;
    public string StaminaRegen;
    public string ManaRegen;
    public string CrowdConteolResist;
    public string ElementResist;
    public string WeaponSlot_1;
    public string WeaponSlot_2;
    public string MasteryWeapon_1;
    public string MasteryWeapon_2;
    public string Element;
    public string HelmentSlot;
    public string ArmorSlot;
    public string PantSlot;
    public string ShoeSlot;
    public string GloveSlot;
    public string NecklaceSlot;
    public string RingSlot_1;
    public string RingSlot_2;
    public string Accessory_1;
    public string Accessory_2;
    public string PassiveSkill_1;
    public string PassiveSkill_2;
    public string SkillSlot_1;
    public string SkillSlot_2;
    public string UltimateSkill;
    public string LvPassive_1;
    public string LvPassive_2;
    public string LvSkill_1;
    public string LvSkill_2;
    public string LvUltimate;
    public string PassiveCoolDown_1;
    public string PassiveCoolDown_2;
    public string SkillCoolDown_1;
    public string SkillCoolDown_2;
    public string UltimateCoolDown;
    public string ImageURL;
}

public class Data : MonoBehaviour
{
    [Header("CSV Link")]
    public string csvUrl = "https://docs.google.com/spreadsheets/d/1TrGl4WXsMKhWdeT8l4bwGRiRvOYAPYDwUcWLq3bEIEY/edit?usp=sharing";

    public List<CharacterData> characters = new List<CharacterData>();

    void Start()
    {
        StartCoroutine(LoadCSV());
    }
    public void load()
    {
        StartCoroutine(LoadCSV());
    }
    public void clear()
    {
        characters.Clear();
    }


    IEnumerator LoadCSV()
    {
        UnityWebRequest www = UnityWebRequest.Get(csvUrl);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string csvData = www.downloadHandler.text;
            ParseCSV(csvData);
        }
        else
        {
            Debug.LogError("โหลด CSV ไม่ได้: " + www.error);
        }
    }


    void ParseCSV(string csvData)
    {
        string[] rows = csvData.Split('\n');

        for (int i = 1; i < rows.Length; i++) // ข้ามแถวแรก (หัวตาราง)
        {
            if (string.IsNullOrWhiteSpace(rows[i])) continue;

            string[] cols = rows[i].Split(',');
            if (cols.Length < 4) continue;

            CharacterData c = new CharacterData();
            c.Name = cols[0];
            c.Job = cols[1];
            c.HP = cols[2];
            c.MaxHP = cols[3];
            c.Def = cols[4];
            c.MDef = cols[5];
            c.Atk = cols[6];
            c.ASpd = cols[7];
            c.Mp = cols[8];
            c.CSpd = cols[9];
            c.Spd = cols[10];
            c.Lv = cols[11];
            c.Exp = cols[12];
            c.Luck = cols[13];
            c.CriRate = cols[14];
            c.CriDmg = cols[15];
            c.Stamina = cols[16];
            c.MaxStamina = cols[17];
            c.Mana = cols[18];
            c.MaxMana = cols[19];
            c.Titel = cols[20];
            c.Money = cols[21];
            c.Reputation = cols[22];
            c.Karma = cols[23];
            c.Hornor = cols[24];
            c.Team = cols[25];
            c.HpRegen = cols[26];
            c.StaminaRegen = cols[27];
            c.ManaRegen = cols[28];
            c.CrowdConteolResist = cols[29];
            c.ElementResist = cols[30];
            c.WeaponSlot_1 = cols[31];
            c.WeaponSlot_2 = cols[32];
            c.MasteryWeapon_1 = cols[33];
            c.MasteryWeapon_2 = cols[34];
            c.Element = cols[35];
            c.HelmentSlot = cols[36];
            c.ArmorSlot = cols[37];
            c.PantSlot = cols[38];
            c.ShoeSlot = cols[39];
            c.GloveSlot = cols[40];
            c.NecklaceSlot = cols[41];
            c.RingSlot_1 = cols[42];
            c.RingSlot_2 = cols[43];
            c.Accessory_1 = cols[44];
            c.Accessory_2 = cols[45];
            c.PassiveSkill_1 = cols[46];
            c.PassiveSkill_2 = cols[47];
            c.SkillSlot_1 = cols[48];
            c.SkillSlot_2 = cols[49];
            c.UltimateSkill = cols[50];
            c.LvPassive_1 = cols[51];
            c.LvPassive_2 = cols[52];
            c.LvSkill_1 = cols[53];
            c.LvSkill_2 = cols[54];
            c.LvUltimate = cols[55];
            c.PassiveCoolDown_1 = cols[56];
            c.PassiveCoolDown_2 = cols[57];
            c.SkillCoolDown_1 = cols[58];
            c.SkillCoolDown_2 = cols[59];
            c.UltimateCoolDown = cols[60];
            c.ImageURL = cols[61];
            characters.Add(c);
        }
    }

    public CharacterData GetCharacter(string name)
    {
        return characters.Find(c => c.Name == name);
    }
}
