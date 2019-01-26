using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineConeEventTalk : MonoBehaviour
{

    public ProgressFlag PineConeEventTalkFlag;
    public ProgressFlag PineConeEventCollectFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        if (Progress.Instance.GetProgressFlagState(PineConeEventTalkFlag) == 0)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "Let’s get the pine cones to make our bird feeders. The squirrels might have hidden some, they're hard to find these days."
                }
            ));

            Progress.Instance.IncrementProgressFlag(PineConeEventTalkFlag);
        }
        else
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "Now we dip the pine cones in suet and cover them with seeds. Maybe the birds will come back this year!"
                }
            ));
        }
    }
}