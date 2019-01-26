using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
  public static LevelTransition Instance
  {
    get
    {
      return Singleton.GetExistingInstance<LevelTransition>();
    }
  }

  public Image FadeToBlackImage;
  public AudioSource Music;
  public bool ShouldFadeIn = true;
  public float FadeDuration = 1;

  void Start()
  {
    if (ShouldFadeIn)
    {
      PauseState.Instance.CurrentState = PauseState.State.TRANSITION;
      FadeToBlackImage.gameObject.SetActive(true);
      FadeToBlackImage.color = Color.black;
      if (Music)
      {
        Music.volume = 0;
        DOTween.To(() => Music.volume, x => Music.volume = x, 1, FadeDuration);
      }
      DOTween
        .To(
          () => FadeToBlackImage.color,
          x => FadeToBlackImage.color = x,
          new Color(0, 0, 0, 0),
          FadeDuration
        )
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
          PauseState.Instance.CurrentState = PauseState.State.WALKING;
          FadeToBlackImage.gameObject.SetActive(false);
        });
    }
  }

  public void NextLevel(int index)
  {
    var asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    asyncLoad.allowSceneActivation = false;

    PauseState.Instance.CurrentState = PauseState.State.TRANSITION;
    FadeToBlackImage.gameObject.SetActive(true);
    FadeToBlackImage.color = new Color(0, 0, 0, 0);
    if (Music)
    {
      DOTween.To(() => Music.volume, x => Music.volume = x, 0, FadeDuration);
    }
    DOTween
      .To(
        () => FadeToBlackImage.color,
        x => FadeToBlackImage.color = x,
        Color.black,
        FadeDuration
      )
      .SetEase(Ease.Linear)
      .OnComplete(() =>
      {
        asyncLoad.allowSceneActivation = true;
      });
  }

  public void NextLevel(string scenePath)
  {
    NextLevel(SceneUtility.GetBuildIndexByScenePath(scenePath));
  }
}