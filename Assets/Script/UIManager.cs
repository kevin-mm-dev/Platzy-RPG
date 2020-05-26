using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Slider playerHealthBar;
    public Slider expBar;
    public Slider volumenBar;
    public Text playerHealthText;
    public TextMeshProUGUI playerLevelText;
    public TextMeshProUGUI listQuests;

    public HealthManager playerHealthManager;
    public CharacterStats status;
    public QuestManager managerQuests;


    void Update () {
        FindObjectOfType<AudioVManager>().currentVolumeLevel=volumenBar.value;
        ///Por si subimos de nivel
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        expBar.maxValue = status.expToLevelUp[status.currentLevel];
        expBar.value = status.currentExp;

        StringBuilder sb = new StringBuilder ("HP: ");
        sb.Append (playerHealthManager.currentHealth);
        sb.Append ("/");
        sb.Append (playerHealthManager.maxHealth);
        playerHealthText.text = sb.ToString ();
        sb = new StringBuilder ();
        sb.Append ("<size=3rem> " + status.currentLevel + "</size>");
        sb.Append ("\n");
        sb.Append ("LEVEL");
        playerLevelText.text = sb.ToString ();

    }

    public void UpdateQuestToUI (int idQuest) {
        if (managerQuests.quests[idQuest].needsEnemy) {
            //Hacer conteo de enemigos
            if (managerQuests.quests[idQuest].enemiesKilled == managerQuests.quests[idQuest].numberOfEnemies) {
                StringBuilder sb = new StringBuilder ("<color=#008F39>" + managerQuests.quests[idQuest].StartText);
                sb.Append (": " + managerQuests.quests[idQuest].enemiesKilled + "/" + managerQuests.quests[idQuest].numberOfEnemies+"</color>");
                listQuests.text = sb.ToString ();
            } else {
                StringBuilder sb = new StringBuilder (managerQuests.quests[idQuest].StartText);
                sb.Append (": " + managerQuests.quests[idQuest].enemiesKilled + "/" + managerQuests.quests[idQuest].numberOfEnemies);
                listQuests.text = sb.ToString ();
            }

        } else if (managerQuests.quests[idQuest].needsItem) {
            //Hacer chequeo
        } else if (!managerQuests.quests[idQuest].needsEnemy && !managerQuests.quests[idQuest].needsEnemy) {
            //Legar a x lugar
        }
    }
}