using System.Collections;
using UnityEngine;

public class RaspberriesEvent : MonoBehaviour
{
    public ProgressFlag MomTalkFlag;
    public ProgressFlag ChristmasLightFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());

    }

    public IEnumerator EventCoroutine()
    {
        if (Progress.Instance.GetProgressFlagState(MomTalkFlag) >= 1 &&
          Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 6)
        {
            Progress.Instance.IncrementProgressFlag(ChristmasLightFlag);
            if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) == 6)
            {
                yield return StartCoroutine(DialogSystem.Instance.ShowText(
        new DialogMessage
        {
            Text = "* You got the raspberries. Mom is going to be so proud!"
        }
      ));
            }

        }
        if (Progress.Instance.GetProgressFlagState(MomTalkFlag) >= 1) {
            Destroy(transform.parent.gameObject);
        }
        
    }
}