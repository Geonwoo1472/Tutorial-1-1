using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
���� �۾�
-Ÿ��Ʋ -> ����ȭ�� �� ���̵�ȿ��
-���̵� ȿ�� �� ĳ���� ������ ����
 */

public enum FadeState
{
    FadeIn = 0,
    FadeOut,
    FadeInOut,
    FadeLoopInOut,
    FadeOutIn,
    FadeLoopOutIn
}

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;


    [SerializeField]
    private AnimationCurve fadeCurve;

    private Image image;

    private FadeState fadeState; // ���̵� ���� ȿ��

    private void Awake()
    {
        image = GetComponent<Image>();

    }


    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
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
            // percent�� 0�̶�� start�� ��ȯ / 1�̶�� end /0.5��� start�� end������ �߰������� ��ȯ
            //color.a = Mathf.Lerp(start, end, percent);

            //�����
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));

            image.color = color;

            // �Լ� �ݺ� ��
            yield return null;
        }
    }
}