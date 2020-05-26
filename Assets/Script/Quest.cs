using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {
    public int questID;
    private QuestManager manager;
    CharacterStats statusPlayer;
    public UIManager managerUI;
    public string StartText, completeText;
    public int expToGive;
    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies = 0;
    public int enemiesKilled = 0;

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (needsItem && manager.itemCollected.Equals (itemNeeded)) {
            manager.itemCollected = null;
            CompleteQuest ();
        }

        if(needsEnemy && manager.enemyKilled != null){
			if(manager.enemyKilled.Equals(enemyName)){
				manager.enemyKilled = null;
				enemiesKilled++;
				if(enemiesKilled >= numberOfEnemies){
					CompleteQuest();
				}	
                managerUI.UpdateQuestToUI(questID);
			}
		}
    }

    public void StartQuest () {
        managerUI = FindObjectOfType<UIManager> ();
        manager = FindObjectOfType<QuestManager> ();
        manager.ShowQuestText (StartText);
        managerUI.UpdateQuestToUI (questID);
    }
    public void CompleteQuest () {
        statusPlayer = FindObjectOfType<CharacterStats> ();
        statusPlayer.AddExperience (expToGive);
        manager.ShowQuestText (completeText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive (false);
    }
}