using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public int maxHP;
    public int currentHP;


    void Start()
    {
        currentHP = maxHP;
    }
    
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
     
        if (currentHP < 0) 
        {
            currentHP = 0; 
        }
        
        if (currentHP <= 0)
        {
            //unit has died
            SceneManager.LoadScene("Loss");
            return true;
        }
        else
        {
            //unit is still alive
            return false;
        }
    }
}
