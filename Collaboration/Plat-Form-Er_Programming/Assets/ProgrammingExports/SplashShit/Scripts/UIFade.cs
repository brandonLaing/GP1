using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFade : MonoBehaviour
{
  public bool fadeIn = true;
  public Image fadeImage;
  public float fadeRate;
  private float targetAlpha;
  public float fadeInWaitTime;
  public float stayWaitTime;
  public float fadeOutWaitTime;
  public string nextSceneName;

  private void Start()
  {
    StartCoroutine(FadeTimeing());

  }
  private void Update()
  {
    Color curColor = fadeImage.color;
    float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
    if (alphaDiff > 0.0001F)
    {
      curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
      fadeImage.color = curColor;

    }
  }

  IEnumerator FadeTimeing()
  {
    Debug.Log("Fading in");

    FadeOut();
    yield return new WaitForSeconds(fadeInWaitTime);
    yield return new WaitForSeconds(stayWaitTime);
    Debug.Log("Fading out");

    FadeIn();
    yield return new WaitForSeconds(fadeOutWaitTime);
    Debug.Log("loading nextScene");

    SceneManager.LoadScene(nextSceneName);

  }

  public void FadeOut()
  {
    targetAlpha = 0.0F;

  }

  public void FadeIn()
  {
    targetAlpha = 1.0F;

  }
}
