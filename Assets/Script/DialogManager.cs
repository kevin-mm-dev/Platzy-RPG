using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool dailogActive;
    public string[] dialogLines; 
    public int currentDialogLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dailogActive && Input.GetKeyDown(KeyCode.Space)){
            currentDialogLine++;
        }
        if (currentDialogLine>=dialogLines.Length){
            dailogActive=false;
            dialogBox.SetActive(false);
            currentDialogLine=0;
        }else{
            dialogText.text=dialogLines[currentDialogLine];
        }
    }

    public void ShowDialog(string[] linesText){
        dailogActive=true;
        dialogBox.SetActive(true);
        currentDialogLine=0;
        dialogLines=linesText;
    }
}

