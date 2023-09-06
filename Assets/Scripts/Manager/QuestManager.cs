using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; // ����Ʈ ��ȭ ����

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData(); 
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("�� ������Ʈ �ȳ� �ޱ�", new int[] { 1000,2000 }));
        questList.Add(20, new QuestData("A�� ???�԰� �����ϱ�", new int[] { 3000 }));
        questList.Add(30, new QuestData("Ʃ�ʹ����� �����Ϸ� ����", new int[] { 4000 }));
        questList.Add(40, new QuestData("������Ʈ �ϼ��ؼ� �������Ŵ��������� �����ϱ�", new int[] { 100,1000 }));
        questList.Add(50, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id) //NPC Id�� �ް� ����Ʈ ��ȣ�� ��ȯ
    {
        return questId + questActionIndex; 
    }

    //��ȭ ������ ���� ����Ʈ ��ȭ ������ �ø��� �Լ�
    public string CheckQuest(int id) //NPC id
    {
        //������ �°� ��ȭ ���� ���� ����Ʈ ��ȭ ������ �ø�
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //����Ʈ ��ȭ ������ ���� �������� �� ����Ʈ ��ȣ ����
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName; 
    }

    //�����ε�
    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0; 
    }
}
