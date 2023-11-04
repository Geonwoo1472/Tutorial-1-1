using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*외부에서도 참조하니 일단 여기에서 관리
  용이하게 관리하는 방법이 있다면 이동시킬 것 */
public enum FadeState
{
    FadeIn = 0,
    FadeOut,
    FadeInOut,
    FadeLoopInOut,
    FadeOutIn,
    FadeLoopOutIn
}

/// <summary>
/// #용도#
/// 부착된 Image컴포넌트의 이미지 알파 값을 서서히 변경시킵니다.
/// 
/// #부착 오브젝트#
/// FadeImage
/// 
/// #Method#
/// -public void OnFade(FadeState)
/// FadeIn 호출 시 이미지의 알파 값이 1부터 서서히 0으로 수렴합니다.
/// FadeOut 호출 시 이미지의 알파 값이 0부터 서서히 1로 수렴합니다.
/// FadeInOut 호출 시 이미지의 알파 값이 0으로 서서히 수렴하고 이후 1로 서서히 수렴합니다.
/// FadeOutIn 호출 시 이미지의 알파 값이 1로 서서히 수렴하고 이후 0으로 서서히 수렴합니다.
/// 
/// FadeLoopInOut , FadeLoopOutIn  호출 시 무한으로 반복합니다.
/// </summary>

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;


    [SerializeField]
    private AnimationCurve fadeCurve;

    private Image image;

    private FadeState fadeState; // 페이드 상태 효과

    private void Awake()
    {
        image = GetComponent<Image>();

    }


    public void OnFade(FadeState state, float time = 1)
    {
        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(time, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, time));
                break;
            case FadeState.FadeInOut:
            case FadeState.FadeLoopInOut:
                StartCoroutine(FadeInOut());
                break;
            case FadeState.FadeOutIn:
            case FadeState.FadeLoopOutIn:
                StartCoroutine(FadeOutIn());
                break;

        }

    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));

            if (fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    private IEnumerator FadeOutIn()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(0, 1));

            yield return StartCoroutine(Fade(1, 0));

            if (fadeState == FadeState.FadeOutIn)
            {
                break;
            }
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            // percent가 0이라면 start를 반환 / 1이라면 end /0.5라면 start와 end사이의 중간지점을 반환
            //color.a = Mathf.Lerp(start, end, percent);

            //곡선형태
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));

            image.color = color;

            // 함수 반복 끝
            yield return null;
        }
    }
}
