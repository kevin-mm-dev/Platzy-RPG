﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestItem : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        manager=FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            if (manager.quests[questID].gameObject.activeInHierarchy&& !manager.questCompleted[questID]){
                manager.itemCollected=itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
