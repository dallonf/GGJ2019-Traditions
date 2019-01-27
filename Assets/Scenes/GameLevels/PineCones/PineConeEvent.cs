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
    if (Progress.Instance.GetProgressFlagState (PineConeEventCollectFlag) < 4)
    {
      Progress.Instance.IncrementProgressFlag (PineConeEventCollectFlag);
      yield return StartCoroutine (DialogSystem.Instance.ShowText(
        new DialogMessage
        {
          Text = "* You got a pinecone *"
        }
      ));
    }

    Destroy (this.gameObject);
    yield return null;
  }
}