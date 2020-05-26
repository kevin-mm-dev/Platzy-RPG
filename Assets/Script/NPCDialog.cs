using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;
    // Start is called before the first frame update
    void Start()
    {
        /// para encontrar por script en un GameObject
        /// para encontrar por tipo de objeto
        manager=FindObjectOfType<DialogManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            playerInTheZone=true;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")){
            playerInTheZone=false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone && Input.GetKeyDown(KeyCode.F))
        {
            manager.ShowDialog(dialog);
            if (gameObject.GetComponentInParent<NPCMovement>()!=null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking=true;
            }
        }
    }
}
