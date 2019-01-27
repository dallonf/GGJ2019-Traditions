using System.Collections;
using UnityEngine;

public class PineConeCollectEvent : MonoBehaviour
{
  public ProgressFlag PineConeEventCollectFlag;

  public void TriggerEvent()
  {
    StartCoroutine(EventCoroutine());
  }

  public IEnumerator EventCoroutine()
  {
    if (Progress.Instance.GetProgressFlagState (PineConeEventCollectFlag) < 8)
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