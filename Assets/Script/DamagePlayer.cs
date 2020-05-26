using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float timeToRevivePlayer;
    float timeToRevivalCounter;
    private GameObject thePlayer;
    bool playerReviving;
    public int damage;

    // Update is called once per frame
    // void Update()
    // {
    //     if (playerReviving)
    //     {
    //         timeToRevivalCounter-=Time.deltaTime;
    //         if (timeToRevivalCounter<0)
    //         {
    //             playerReviving=false;
    //             thePlayer.SetActive(true);
    //         }
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            // other.gameObject.SetActive(false);
            // playerReviving=true;
            // timeToRevivalCounter = timeToRevivePlayer;
            // thePlayer=other.gameObject;

            CharacterStats stats=other.gameObject.GetComponent<CharacterStats>();
            int totalDamage=damage-stats.defenseLevels[stats.currentLevel];
            if (totalDamage<=0)
            {
                totalDamage=1; 
            }
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);
            var clone = (GameObject) Instantiate(other.gameObject.GetComponent<HealthManager>().damageNumber,
            other.transform.position,
            Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints=damage;

        }
    }
}
