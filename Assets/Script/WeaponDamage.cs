using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    
    public int damage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber; 
    private CharacterStats stats;


    private void Start() {
        ///Obtenemos el componente por referencia / del padre
        stats=GetComponentInParent<CharacterStats>();
        //stats=transform.parent.GetComponent<CharacterStats>();
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            int totalDame=damage;
            if (stats!=null)
            {
                totalDame+=stats.strengthLevels[stats.currentLevel];
            }


            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDame);
            Instantiate(hurtAnimation,hitPoint.transform.position,
                            hitPoint.transform.rotation);
            // / Asignar Instanciar un GameObject a una variable 
            var clone = (GameObject) Instantiate(damageNumber,
            hitPoint.transform.position,
            Quaternion.Euler(Vector3.zero));
            

            clone.GetComponent<DamageNumber>().damagePoints=totalDame;
        }
    }
}
