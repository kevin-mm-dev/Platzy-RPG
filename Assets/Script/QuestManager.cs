using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
     public string enemyKilled;
     

    public Quest[] quests;
    public bool[] questCompleted;

    private DialogManager manager;
    public string itemCollected;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted=new bool[quests.Length];
        manager=FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questsText){
        string[] dialogLines=new string[]{
            questsText
        };
        manager.ShowDialog(dialogLines);
    }
}
