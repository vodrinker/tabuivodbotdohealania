using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// siema vod
public class HealBot : MonoBehaviour
{

    public BarScript target;
    public BarScript[] targets;
    public int skillChecked;
    public bool aoeCooldown;

    public void UseAbility()
    {
        switch (skillChecked)
        {
            case 1:
                BasicHeal();
                break;
            case 2:
                QuickHeal();
                break;
            default:
                
                break;
        }
        
    }

    public void PickSpell(int spellNumber)
    {
        skillChecked = spellNumber;
    }

    public void PickTarget(int targetID)
    {
        target = targets[targetID];
    }

    public void BasicHeal()
    {
        if (targets[0].currentMP >= 10)
        {
            target.currentHP += 50;
            targets[0].currentMP -= 10;
        }
    }

    public void QuickHeal()
    {
        if (targets[0].currentMP >= 3)
        {
            target.currentHP += 20;
            targets[0].currentMP -= 3;
        }
    }

    public IEnumerator AOECooldown()
    {
        yield return new WaitForSeconds(5);
        aoeCooldown = true;
    }

    public void AOEHeal()
    {
        if (aoeCooldown && targets[0].currentMP >= 25)
        {
            for (int i = 0;i< targets.Length; i++)
            {
                targets[i].currentHP += 50;
            }
            targets[0].currentMP -= 25;
            aoeCooldown = false;
            StartCoroutine(AOECooldown());
        }
    }

    // Use this for initialization
    void Start ()
    {
        aoeCooldown = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
