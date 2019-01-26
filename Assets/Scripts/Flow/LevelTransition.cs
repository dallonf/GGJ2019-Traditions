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
  public float FadeDuration = 1;

  void Start()
  {
    PauseState.Instance.CurrentState = PauseState.State.TRANSITION;
    FadeToBlackImage.gameObject.SetActive(true);
    FadeToBlackImage.color = Color.black;
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

  public void NextLevel(int index)
  {
    var asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    asyncLoad.allowSceneActivation = false;

    PauseState.Instance.CurrentState = PauseState.State.TRANSITION;
    FadeToBlackImage.gameObject.SetActive(true);
    FadeToBlackImage.color = new Color(0, 0, 0, 0);
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