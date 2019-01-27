using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspberriesMomTalk : MonoBehaviour
{

    public ProgressFlag MomTalkFlag;
    public ProgressFlag ChristmasLightFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        //6 of them
        if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 6)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "It’s been harder to find what we need at the market. Alex, could you see if you can find some <color=\"red\">raspberries</color> in the backyard?"
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
                        Text = "I’m glad we have our own victory garden that can provide us with these little treats. It’s not 4th-of-July without pie!"
                }
            ));
            LevelTransition.Instance.NextLevel("Scenes/GameLevels/YellowRibbon");
        }
    }
}