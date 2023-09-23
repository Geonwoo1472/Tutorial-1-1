using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndingNarration : MonoBehaviour
{

    public Text ChatText; // 실제 채팅이 나오는 텍스트


    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public string writerText = ""; // 입력 받기 위한 문장

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
    }

    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }


    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        // 텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        // 키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice() // yield return StartCoroutine(NormalChat("원하는 문구 입력"));
    {
        yield return StartCoroutine(NormalChat("탈출했다."));
        yield return StartCoroutine(NormalChat("레전드다."));
        yield return StartCoroutine(NormalChat("그리고"));
        yield return StartCoroutine(NormalChat("나는 살아있다."));
    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }