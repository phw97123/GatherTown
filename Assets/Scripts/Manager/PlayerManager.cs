using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerManager : MonoBehaviour
{
    public TMP_Text playeNameTxt;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playeNameTxt.text = PlayerPrefs.GetString("PlayerName"); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� ���� �̸� �ؽ�Ʈ�� ������ǥ���� ȭ�� ��ǥ�� ��ȯ�Ͽ� ��ġ�� ���� 
        //�÷��̾ ��� ��ġ�� �ֵ��� ������� ȭ�� ���� ��Ȯ�� ��ġ�� �ؽ�Ʈ�� ǥ���� �� �ִ� 
        playeNameTxt.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.3f, 0)); 
    }
}
