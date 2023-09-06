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
        //플레이어 위에 이름 텍스트를 월드좌표에서 화면 좌표로 변환하여 위치를 고정 
        //플레이어가 어느 위치에 있든지 상관없이 화면 상의 정확한 위치에 텍스트를 표시할 수 있다 
        playeNameTxt.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.3f, 0)); 
    }
}
