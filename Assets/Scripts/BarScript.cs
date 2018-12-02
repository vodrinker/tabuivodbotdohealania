using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private string CreateHPText()
    {
        string bufor = "HP: ";
        bufor += currentHP.ToString() + "/" + maxHP.ToString();
        return bufor;
    }

    private string CreateMPText()
    {
        string bufor = "MP: ";
        bufor += currentMP.ToString() + "/" + maxMP.ToString();
        return bufor;
    }

    private float FillAmount(float currentAmount, float maxAmount)
    {
        float fillAmountBufor = (float)currentAmount / (float)maxAmount;
        if (currentAmount >= maxAmount) fillAmountBufor = 1f;
        if (currentAmount == 0f) fillAmountBufor = 0f;
        return fillAmountBufor;
    }

    public void FixValues()
    {
        if (currentHP < 0) currentHP = 0;
        if (maxHP < currentHP) currentHP = maxHP;
        if (currentMP < 0) currentMP = 0;
        if (maxMP < currentMP) currentMP = maxMP;
    }

    public void ManaRegen()
    {
        if (manaLicznik >= 33)
        {
            manaLicznik = 0;
            currentMP++;
        }
        else
        {
            manaLicznik++;
        }
    }



    public int maxHP = 289;
    public int currentHP;
    public int maxMP = 100;
    public int currentMP;
    public Image healthBar;
    public Image manaBar;
    public Text hpText;
    public Text mpText;
    private int manaLicznik;



    //-----------------------------------------
    void Start ()
    {
        manaLicznik = 0;
        currentHP = maxHP;
        currentMP = maxMP;
    }
	
	// Update is called once per frame
	void Update ()
    {
        FixValues();
        healthBar.fillAmount = FillAmount(currentHP, maxHP);
        manaBar.fillAmount = FillAmount(currentMP, maxMP);
        hpText.text = CreateHPText();
        mpText.text = CreateMPText();
        ManaRegen();
    }
}
