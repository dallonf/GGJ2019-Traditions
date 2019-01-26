using System.Collections;
using UnityEngine;

public class ChristmasLightSwitchEvent : MonoBehaviour
{
  public ProgressFlag ChristmasLightFlag;

  public void TriggerEvent()
  {
    if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 1)
    {
      Progress.Instance.IncrementProgressFlag(ChristmasLightFlag);
      StartCoroutine(EventCoroutine());
    }
  }

  public IEnumerator EventCoroutine()
  {
    yield return StartCoroutine(DialogSystem.Instance.ShowText("Mom: Yay you turned on the Christmas tree lights"));
    yield return StartCoroutine(DialogSystem.Instance.ShowText("Alex: They're pretty"));
  }
}