using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager; 
    public GameObject talkPanel; 
    public TMP_Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex; 
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null) //대화가 끝나면
        {
            isAction = false;
            talkIndex = 0; //초기화 
            return; 
        }

        if(isNpc)
        {
            talkText.text = talkData; 
        }
        else
        {
            talkText.text = talkData; 
        }

        isAction = true;
        talkIndex++; 
    }
}
