using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SyncCameraGroup))]
public class PineConeCameraGroup : MonoBehaviour
{

  public Transform PlayerCharacter;
  public Transform[] PineCones;
  public float DistanceToShowPineCone = 35;
  private SyncCameraGroup syncCameraGroup;

  void Awake()
  {
    syncCameraGroup = GetComponent<SyncCameraGroup>();
  }

  // Update is called once per frame
  void Update()
  {
    var list = new List<Transform>();
    list.Add(PlayerCharacter);
    foreach (var pineCone in PineCones)
    {
      if (pineCone &&
        (VectorMath.Flatten(pineCone.position) -
          VectorMath.Flatten(PlayerCharacter.position)).sqrMagnitude <
        DistanceToShowPineCone * DistanceToShowPineCone)
      {
        list.Add(pineCone);
      }
    }
    // if (Progress.Instance.GetProgressFlagState(DadTalkFlag) == 0)
    // {
    //   list.Add(Dad);
    // }
    // else if (Progress.Instance.GetProgressFlagState(GotRibbonFlag) == 0)
    // {
    //   list.Add(RibbonOnTable);
    // }
    // else
    // {
    //   list.Add(Tree);
    // }

    syncCameraGroup.Targets = list.ToArray();
  }
}