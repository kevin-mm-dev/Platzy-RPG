﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private CoinsManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager= FindObjectOfType<CoinsManager>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
