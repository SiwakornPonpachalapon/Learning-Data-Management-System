using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
public class CharacterSelection : MonoBehaviour
{
    public Data data; // อ้างอิงไปที่สคริปต์ Data ที่โหลด CSV
    public GameObject buttonPrefab; // Prefab ปุ่มตัวละคร
    public Transform buttonParent;  // Content ของ ScrollView

    [Header("UI แสดงข้อมูลตัวละคร")]
    public TMP_Text nameText;
    public TMP_Text jobText;
    public TMP_Text hpText;
    public TMP_Text MaxHP;
    public TMP_Text Def;
    public TMP_Text MDef;
    public TMP_Text Atk;
    public TMP_Text ASpd;
    public TMP_Text Mp;
    public TMP_Text CSpd;
    public TMP_Text Spd;
    public TMP_Text Lv;
    public TMP_Text Exp;
    public TMP_Text Luck;
    public TMP_Text CriRate;
    public TMP_Text CriDmg;
    public TMP_Text Stamina;
    public TMP_Text MaxStamina;
    public TMP_Text Mana;
    public TMP_Text MaxMana;
    public TMP_Text Titel;
    public TMP_Text Money;
    public TMP_Text Reputation;
    public TMP_Text Karma;
    public TMP_Text Hornor;
    public TMP_Text Team;
    public TMP_Text HpRegen;
    public TMP_Text StaminaRegen;
    public TMP_Text ManaRegen;
    public TMP_Text CrowdConteolResist;
    public TMP_Text ElementResist;
    public TMP_Text WeaponSlot_1;
    public TMP_Text WeaponSlot_2;
    public TMP_Text MasteryWeapon_1;
    public TMP_Text MasteryWeapon_2;
    public TMP_Text Element;
    public TMP_Text HelmentSlot;
    public TMP_Text ArmorSlot;
    public TMP_Text PantSlot;
    public TMP_Text ShoeSlot;
    public TMP_Text GloveSlot;
    public TMP_Text NecklaceSlot;
    public TMP_Text RingSlot_1;
    public TMP_Text RingSlot_2;
    public TMP_Text Accessory_1;
    public TMP_Text Accessory_2;
    public TMP_Text PassiveSkill_1;
    public TMP_Text PassiveSkill_2;
    public TMP_Text SkillSlot_1;
    public TMP_Text SkillSlot_2;
    public TMP_Text UltimateSkill;
    public TMP_Text LvPassive_1;
    public TMP_Text LvPassive_2;
    public TMP_Text LvSkill_1;
    public TMP_Text LvSkill_2;
    public TMP_Text LvUltimate;
    public TMP_Text PassiveCoolDown_1;
    public TMP_Text PassiveCoolDown_2;
    public TMP_Text SkillCoolDown_1;
    public TMP_Text SkillCoolDown_2;
    public TMP_Text UltimateCoolDown;
    public RawImage Pa;
    public RawImage imags;

    void Start()
    {
        StartCoroutine(DelayAction(3.0f));

    }

    void GenerateButtons()
    {
        if (data.characters.Count == 0)
        {
            Debug.LogWarning("ยังไม่มีตัวละคร โหลด CSV เสร็จหรือยัง?");
            return;
        }

        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject); // เคลียร์ปุ่มเก่า
        }

        foreach (var c in data.characters)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonParent);
            TMP_Text btnText = btnObj.GetComponentInChildren<TMP_Text>();
            btnText.text = c.Name;

            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(() => SelectCharacter(c));
        }
    }
    IEnumerator LoadImage(string url, RawImage targetRawImage)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("โหลดภาพไม่สำเร็จ: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                targetRawImage.texture = texture;
            }
        }
    }




    void SelectCharacter(CharacterData c)
    {
        StartCoroutine(LoadImage(c.ImageURL, imags));
        nameText.text = "Name: " + c.Name;
        jobText.text = "<b>Job\n</b>" + c.Job;
        hpText.text = "<b>HP\n</b>" + c.HP;
        MaxHP.text = "<b>MaxHP\n</b>" + c.MaxHP;
        Def.text = "<b>Def\n</b>" + c.Def;
        MDef.text = "<b>MDef\n</b>" + c.MDef;
        Atk.text = "<b>Atk\n</b>" + c.Atk;
        ASpd.text = "<b>ASpd\n</b>" + c.ASpd;
        Mp.text = "<b>Mp\n</b>" + c.Mp;
        CSpd.text = "<b>Cspd\n</b>" + c.CSpd;
        Spd.text = "<b>Spd\n</b>" + c.Spd;
        Lv.text = "<b>Lv\n</b>" + c.Lv;
        Exp.text = "<b>Exp\n</b>" + c.Exp;
        Luck.text = "<b>Luck\n</b>" + c.Luck;
        CriRate.text = "<b>CriRate\n</b>" + c.CriRate + "%";
        CriDmg.text = "<b>CriDmg\n</b>" + c.CriDmg + "%";
        Stamina.text = "<b>Sta\n</b>" + c.Stamina;
        MaxStamina.text = "<b>MaxSta\n</b>" + c.MaxStamina;
        Mana.text = "<b>Mana\n</b>" + c.Mana;
        MaxMana.text = "<b>MaxMn\n</b>" + c.MaxMana;
        Titel.text = "" + c.Titel;
        Money.text = "<b>Money\n</b>" + c.Money;
        Reputation.text = "<b>Rep\n</b>" + c.Reputation;
        Karma.text = "<b>Karma\n</b>" + c.Karma;
        Hornor.text = "<b>Honor\n</b>" + c.Hornor;
        Team.text = "<b>Team\n</b>" + c.Team;
        HpRegen.text = "<b>HpRgn\n</b>" + c.HpRegen + "%";
        StaminaRegen.text = "<b>StaRgn\n</b>" + c.StaminaRegen + "%";
        ManaRegen.text = "<b>ManaRgn\n</b>" + c.ManaRegen + "%";
        CrowdConteolResist.text = "<b>CCResit\n</b>" + c.CrowdConteolResist + "%";
        ElementResist.text = "<b>ElemRes\n</b>" + c.ElementResist + "%";
        WeaponSlot_1.text = "<b>Wpn 1\n</b>" + c.WeaponSlot_1;
        WeaponSlot_2.text = "<b>Wpn 2\n</b>" + c.WeaponSlot_2;
        MasteryWeapon_1.text = "<b>Mst 1\n</b>" + c.MasteryWeapon_1;
        MasteryWeapon_2.text = "<b>Mst 2\n</b>" + c.MasteryWeapon_2;
        Element.text = "<b>Element\n</b>" + c.Element;
        HelmentSlot.text = "<b>Helment\n</b>" + c.HelmentSlot;
        ArmorSlot.text = "<b>Armor\n</b>" + c.ArmorSlot;
        PantSlot.text = "<b>Pant\n</b>" + c.PantSlot;
        ShoeSlot.text = "<b>Shoe\n</b>" + c.ShoeSlot;
        GloveSlot.text = "<b>Glove\n</b>" + c.GloveSlot;
        NecklaceSlot.text = "<b>Necklace\n</b>" + c.NecklaceSlot;
        RingSlot_1.text = "<b>Ring 1\n</b>" + c.RingSlot_1;
        RingSlot_2.text = "<b>Ring 2\n</b>" + c.RingSlot_2;
        Accessory_1.text = "<b>Acc 2\n</b>" + c.Accessory_1;
        Accessory_2.text = "<b>Acc 2\n</b>" + c.Accessory_2;
        PassiveSkill_1.text = "<b>PSkill 1\n</b>" + c.PassiveSkill_1;
        PassiveSkill_2.text = "<b>PSkill 2\n</b>" + c.PassiveSkill_2;
        SkillSlot_1.text = "<b>Skill 1\n</b>" + c.SkillSlot_1;
        SkillSlot_2.text = "<b>Skill 2\n</b>" + c.SkillSlot_2;
        UltimateSkill.text = "<b>Ult\n</b>" + c.UltimateSkill;
        LvPassive_1.text = "<b>LvPs 1\n</b>" + c.LvPassive_1;
        LvPassive_2.text = "<b>LvPs 2\n</b>" + c.LvPassive_2;
        LvSkill_1.text = "<b>LvSkill 1\n</b>" + c.LvSkill_1;
        LvSkill_2.text = "<b>LvSkill 2\n</b>" + c.LvSkill_2;
        LvUltimate.text = "<b>LvUlt\n</b>" + c.LvUltimate;
        PassiveCoolDown_1.text = "<b>CdPs 1\n</b>" + c.PassiveCoolDown_1;
        PassiveCoolDown_2.text = "<b>CdPs 2\n</b>" + c.PassiveCoolDown_2;
        SkillCoolDown_1.text = "<b>CdSkill 1\n</b>" + c.SkillCoolDown_1;
        SkillCoolDown_2.text = "<b>CdSkill 2\n</b>" + c.SkillCoolDown_2;
        UltimateCoolDown.text = "<b>CdUlt\n</b>" + c.UltimateCoolDown;
        if (c.Team == "Good")
        {
            Pa.color = new Color32(184,252,255,255);
        }
        else if (c.Team == "Bad")
        {
            Pa.color = new Color32(238, 121, 118,255);
        }
        else{
            Pa.color = new Color32(255,255,255,255);
        }
    }
    public IEnumerator DelayAction(float tim)
    {
        Debug.Log("Delay!!");
        yield return new WaitForSeconds(tim); 
        GenerateButtons();
        Debug.Log("DelayFinish");
    }

    public void Refect()
    {
        StartCoroutine(DelayAction(3.0f));
    }
}
