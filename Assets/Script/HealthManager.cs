using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    public int expWhenDefeated;

    private SpriteRenderer characterRender;

    public GameObject damageNumber;

    public string enemyName;
    QuestManager manager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        characterRender=GetComponent<SpriteRenderer>();
        manager=FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0){
            if (gameObject.CompareTag("Enemy"))
            {
                manager.enemyKilled=enemyName;
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            }else if (gameObject.CompareTag("Player")){
                FindObjectOfType<SFXManager>().playerDead.Play();
            }
            gameObject.SetActive(false);
        }
        if (flashActive)
        {
            flashCounter-=Time.deltaTime;
            if (flashCounter>flashLength*0.66f)
            {
                ToggleColor(false);
            }else if (flashCounter>flashLength*0.33f){
                ToggleColor(true);
            }else if (flashCounter>0){
                ToggleColor(false);
            }else{
                ToggleColor(true);
                flashActive=false;
            }
        }
        
    }
    public void DamageCharacter(int damage){
        currentHealth-=damage;
            FindObjectOfType<SFXManager>().playerHurt.Play();
        if (flashLength>0){
            flashActive=true;
            flashCounter=flashLength;
        }
    }
    public void UpdateMaxHealth(int newMaxHealth){
        maxHealth=newMaxHealth;
        currentHealth=maxHealth;
    }
    private void ToggleColor(bool visible){
        characterRender.color=new Color(
            characterRender.color.r,
            characterRender.color.g,
            characterRender.color.b,
            (visible? 1.0f:0.0f));
    }
}
