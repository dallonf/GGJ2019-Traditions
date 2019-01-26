using UnityEngine;

public class Progress : MonoBehaviour, ISingleton
{
  public static Progress Instance
  {
    get
    {
      return Singleton.GetInstance<Progress>();
    }
  }

  public Mission CurrentMission;
  public int CurrentMissionSteps = 0;

  public void SetNewObjective(Mission newMission)
  {
    CurrentMission = newMission;
    CurrentMissionSteps = 0;
  }
}