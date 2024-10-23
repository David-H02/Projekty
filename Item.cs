using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr, affectDef;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Use(int charToUseOn)
     {
         /*if (GameManager.instance.battleActive)   //-----------------------------
         {                                           //-----------------------------
             charToUseOn = BattleManager.instance.currentTurn; //----------------------------- currentActiveBattler ??
         }                                                               //----------------------------- */

         CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

         if(isItem)
         {
             if(affectHP)
             {
                 selectedChar.currentHP += amountToChange;

                 if(selectedChar.currentHP > selectedChar.maxHP)
                 {
                     selectedChar.currentHP = selectedChar.maxHP;
                 }
             }

             if(affectMP)
             {
                 selectedChar.currentMP += amountToChange;

                 if (selectedChar.currentMP > selectedChar.maxMP)
                 {
                     selectedChar.currentMP = selectedChar.maxMP;
                 }
             } 

             if(affectStr)
             {
                 selectedChar.strength += amountToChange;
             }

            if (affectDef)
            {
                selectedChar.defence += amountToChange;
            }

        }

         if(isWeapon)
         {
             if(selectedChar.equippedWpn != "")
             {
                 GameManager.instance.AddItem(selectedChar.equippedWpn);
             }

             selectedChar.equippedWpn = itemName;
             selectedChar.wpnPwr = weaponStrength;
         }

         if(isArmor)
         {
             if (selectedChar.equippedArmr != "")
             {
                 GameManager.instance.AddItem(selectedChar.equippedArmr);
             }

             selectedChar.equippedArmr = itemName;
             selectedChar.armrPwr = armorStrength;
         }

         if(GameManager.instance.battleActive)
        {
            for (int i = 0; i < BattleManager.instance.playerPositions.Length; i++)
            {
                CharStats thePlayer = GameManager.instance.playerStats[i];

                BattleManager.instance.activeBattlers[i].currentHP = thePlayer.currentHP;
                BattleManager.instance.activeBattlers[i].maxHP = thePlayer.maxHP;
                BattleManager.instance.activeBattlers[i].currentMP = thePlayer.currentMP;
                BattleManager.instance.activeBattlers[i].maxMP = thePlayer.maxMP;
                BattleManager.instance.activeBattlers[i].strength = thePlayer.strength;
                BattleManager.instance.activeBattlers[i].defence = thePlayer.defence;
                BattleManager.instance.activeBattlers[i].wpnPower = thePlayer.wpnPwr;
                BattleManager.instance.activeBattlers[i].armrPower = thePlayer.armrPwr;

                BattleManager.instance.UpdateUIStats();
            }
        }
        

        GameManager.instance.RemoveItem(itemName);
     } 

   /* //Using Items During Battle ---------------------------------------------------------------------------
    public void Use(int charToUseOn)
    {
        if (GameManager.instance.battleActive)
        {
            charToUseOn = BattleManager.instance.currentTurn;
        }

        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (selectedChar.currentHP != selectedChar.maxHP)
            {
                if (affectHP)
                {
                    selectedChar.currentHP += amountToChange;
                    if (selectedChar.currentHP > selectedChar.maxHP)
                    {
                        selectedChar.currentHP = selectedChar.maxHP;
                    }

                    if (GameManager.instance.battleActive)
                    {
                        charToUseOn = BattleManager.instance.currentTurn;
                        BattleManager.instance.activeBattlers[charToUseOn].currentHP += amountToChange;
                        if (BattleManager.instance.activeBattlers[charToUseOn].currentHP > selectedChar.maxHP)
                        {
                            BattleManager.instance.activeBattlers[charToUseOn].currentHP = selectedChar.maxHP;
                        }
                    }
                }

                GameManager.instance.RemoveItem(itemName);
            }

            if (selectedChar.currentMP != selectedChar.maxMP)
            {
                if (affectMP)
                {
                    selectedChar.currentMP += amountToChange;
                    if (selectedChar.currentMP > selectedChar.maxMP)
                    {
                        selectedChar.currentMP = selectedChar.maxMP;
                    }

                    if (GameManager.instance.battleActive)
                    {
                        charToUseOn = BattleManager.instance.currentTurn;
                        BattleManager.instance.activeBattlers[charToUseOn].currentMP += amountToChange;
                        if (BattleManager.instance.activeBattlers[charToUseOn].currentMP > selectedChar.maxMP)
                        {
                            BattleManager.instance.activeBattlers[charToUseOn].currentMP = selectedChar.maxMP;
                        }
                    }

                    GameManager.instance.RemoveItem(itemName);
                }
            }

            if (affectStr)
            {
                selectedChar.strength += amountToChange;

                GameManager.instance.RemoveItem(itemName);
            }
        }

        if (isWeapon)
        {
            if (selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn);
            }

            selectedChar.equippedWpn = itemName;
            selectedChar.wpnPwr = weaponStrength;

            GameManager.instance.RemoveItem(itemName);
        }

        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmr);
            }

            selectedChar.equippedArmr = itemName;
            selectedChar.armrPwr = armorStrength;

            GameManager.instance.RemoveItem(itemName);
        } 
    } //Using Items During Battle -------------------------------------------------- */
}
