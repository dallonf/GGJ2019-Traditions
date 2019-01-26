using System.Collections;
using UnityEngine;

public class PineConeCollectEvent : MonoBehaviour
{
  public ProgressFlag PineConeEventTalkFlag;
  public ProgressFlag PineConeEventCollectFlag;

  public void TriggerEvent()
  {
    StartCoroutine(EventCoroutine());
  }

  public IEnumerator EventCoroutine()
  {
    /* if (Progress.Instance.GetProgressFlagState(PineConeEventCollectFlag) >= 1 &&
      Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 1)
    {
      Progress.Instance.IncrementProgressFlag(ChristmasLightFlag);
      yield return StartCoroutine(DialogSystem.Instance.ShowText(
        new DialogMessage
        {
          Text = "* You turned on the lights. Mom is going to be so proud!"
        }
      ));
    }*/

  }
}