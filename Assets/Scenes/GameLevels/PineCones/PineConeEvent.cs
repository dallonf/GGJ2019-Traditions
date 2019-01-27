using System.Collections;
using UnityEngine;

public class PineConeEvent : MonoBehaviour
{
  public ProgressFlag PineConeEventCollectFlag;

  public void TriggerEvent()
  {
    StartCoroutine(EventCoroutine());
  }

  public IEnumerator EventCoroutine()
  {
    if (Progress.Instance.GetProgressFlagState (PineConeEventCollectFlag) < 3)
    {
      Progress.Instance.IncrementProgressFlag (PineConeEventCollectFlag);
      if (Progress.Instance.GetProgressFlagState (PineConeEventCollectFlag) == 4)
      {
        yield return StartCoroutine (DialogSystem.Instance.ShowText(
          new DialogMessage
          {
            Text = "* You got all the pinecones *"
          }
        ));
      }
      yield return null;
    }

    Destroy (this.gameObject);
    yield return null;
  }
}