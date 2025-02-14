﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OneCreatureManager : MonoBehaviour 
{
    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text HealthText;
    public Text AttackText;
    [Header("Image References")]
    public Image CreatureGraphicImage;
    public Image CreatureGlowImage;

    void Awake()
    {
        if (cardAsset != null)
            ReadCreatureFromAsset();
    }

    private bool canAttackNow = false;
    public bool CanAttackNow
    {
        get
        {
            return canAttackNow;
        }

        set
        {
            canAttackNow = value;

            CreatureGlowImage.enabled = value;
        }
    }

    public void ReadCreatureFromAsset()
    {
        // Change the card graphic sprite
        CreatureGraphicImage.sprite = cardAsset.CardImage;

        AttackText.text = cardAsset.Attack.ToString();
        HealthText.text = cardAsset.MaxHealth.ToString();

        if (PreviewManager != null)
        {
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }	

    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount != 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = System.Math.Min(healthAfter,cardAsset.MaxHealth).ToString();
        }
    }

    public void ChangeStats(int attackAmount,  int healthAmount, int attackAfter, int healthAfter)
    {
        if (attackAmount != 0 || healthAmount != 0)
        {
            StatsEffect.CreateStatsEffect(transform.position, attackAmount, healthAmount);
            AttackText.text = System.Math.Max(attackAfter, 0).ToString();
            HealthText.text = System.Math.Max(healthAfter, 0).ToString();
        }
    }
}
