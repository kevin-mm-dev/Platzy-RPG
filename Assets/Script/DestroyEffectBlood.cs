using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectBlood : MonoBehaviour
{
    // Start is called before the first frame update
      public int tiempo_para_destruir;
    private float contador_tiempo;

    // Start is called before the first frame update
    void Start()
    {
        contador_tiempo = tiempo_para_destruir; //iguala el tiempo para destruir con el contador
    }

    // Update is called once per frame
    void Update()
    {
        contador_tiempo -= Time.deltaTime;//descuenta el tiempo del ultimo renderisado    
        if (contador_tiempo < 0)//si se acaba el tiempo se destruye el objeto
        {
            Destroy(gameObject);
        }
    }
}