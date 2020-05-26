using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para asegurarse de que esta en un collider, porque las misiones necesitamos activarlas con 
//un coliider
[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour
{
    private QuestManager manager;
    public int questID;

    public bool startPoint, endPoint;
    // Start is called before the first frame update
    void Start()
    {
        manager=FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            if (!manager.questCompleted[questID]){
                ///Esto es para revisar si un elemento esta activo en la jeraquia
                ///Esto es para verificar si un elemento esta activo en la jeraquia
                if (startPoint && !manager.quests[questID].gameObject.activeInHierarchy){
                    manager.quests[questID].gameObject.SetActive(true);
                    manager.quests[questID].StartQuest();
                }
                if (endPoint && manager.quests[questID].gameObject.activeInHierarchy)
                {
                    manager.quests[questID].CompleteQuest();
                }
            }
        }
    }
}
