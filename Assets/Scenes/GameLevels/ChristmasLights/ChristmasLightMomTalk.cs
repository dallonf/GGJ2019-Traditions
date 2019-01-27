using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasLightMomTalk : MonoBehaviour
{

    public ProgressFlag MomTalkFlag;
    public ProgressFlag ChristmasLightFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 1)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "All the Christmas lights are hung up. Can you turn on the <color=\"red\">tree</color>, Alex?"
                }
            ));
            if (Progress.Instance.GetProgressFlagState(MomTalkFlag) == 0)
            {
                Progress.Instance.IncrementProgressFlag(MomTalkFlag);
            }
        }
        else
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "We can only leave the lights on for an hour or so. We have to conserve power."
                }
            ));
            LevelTransition.Instance.NextLevel("Scenes/GameLevels/PineCones/PineConesEvent");
        }
    }
}