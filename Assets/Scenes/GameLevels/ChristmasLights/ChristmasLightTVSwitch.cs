using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasLightTVSwitch : MonoBehaviour
{
  public ProgressFlag MomTalkProgressFlag;

  public Sprite SwitchOnSprite;
  public Sprite SwitchOffSprite;

  public SpriteRenderer SpriteRenderer;

  void Start()
  {
    SetSprite();
  }

  void Update()
  {
    SetSprite();
  }

  private void SetSprite()
  {
    bool switchOn = Progress.Instance.GetProgressFlagState(MomTalkProgressFlag) >= 1;
    SpriteRenderer.sprite = switchOn ? SwitchOnSprite : SwitchOffSprite;
  }

  public void HandleTriggerEnter()
  {
    StartCoroutine(_HandleTriggerEnter());
  }

  private IEnumerator _HandleTriggerEnter()
  {
    if (Progress.Instance.GetProgressFlagState(MomTalkProgressFlag) >= 1)
    {
      yield return StartCoroutine(DialogSystem.Instance.ShowText(
        new DialogMessage
        {
          Text = "...conflict escalated over the Thanksgiving holiday between rebel forces along the western border. Citizens are encouraged to limit use of electricity..."
        }
      ));
    }
  }
}