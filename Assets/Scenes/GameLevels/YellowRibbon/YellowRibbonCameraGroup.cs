using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class YellowRibbonCameraGroup : MonoBehaviour
{
    public CinemachineTargetGroup TargetGroup;

    public Transform PlayerCharacter;
    public Transform Dad;
    public Transform RibbonOnTable;
    public Transform Tree;
    public ProgressFlag DadTalkFlag;
    public ProgressFlag GotRibbonFlag;
    public float WeightFadeRate = 1f;
    public float MaxDistance = 60;

    // Update is called once per frame
    void Update()
    {
        var list = new List<Transform>();
        list.Add(PlayerCharacter);
        if (Progress.Instance.GetProgressFlagState(DadTalkFlag) == 0)
        {
            list.Add(Dad);
        }
        else if (Progress.Instance.GetProgressFlagState(GotRibbonFlag) == 0)
        {
            list.Add(RibbonOnTable);
        }
        else
        {
            list.Add(Tree);
        }

        // sync the desired list with the current one, fading in new items' weights
        var newTargetList = new List<CinemachineTargetGroup.Target>();
        foreach (var item in list)
        {
            if (IsTooFarAway(item))
            {
                continue;
            }
            var currentTarget = TargetGroup.m_Targets.FirstOrDefault(x => x.target == item);
            float currentWeight = 0;
            if (currentTarget.target != null)
            {
                currentWeight = currentTarget.weight;
                if (currentWeight < 1)
                {
                    currentWeight = Mathf.Min(1, currentWeight + Time.deltaTime * WeightFadeRate);
                }
            }
            newTargetList.Add(new CinemachineTargetGroup.Target() { target = item, weight = currentWeight });
        }
        // and fade out anything that's missing, and remove anything that's too far away
        foreach (var existingTarget in TargetGroup.m_Targets)
        {
            if (!list.Contains(existingTarget.target) && !IsTooFarAway(existingTarget.target))
            {
                var newTarget = existingTarget;
                newTarget.weight -= WeightFadeRate * Time.deltaTime;
                if (newTarget.weight > 0)
                {
                    newTargetList.Add(newTarget);
                }
            }
        }

        TargetGroup.m_Targets = newTargetList.ToArray();
    }

    private bool IsTooFarAway(Transform target)
    {
        return (target.position - PlayerCharacter.position).sqrMagnitude > MaxDistance * MaxDistance;
    }
}