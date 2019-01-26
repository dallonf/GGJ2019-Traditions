using UnityEngine;

public class PauseState : MonoBehaviour, ISingleton
{
  public static PauseState Instance
  {
    get
    {
      return Singleton.GetInstance<PauseState>();
    }
  }

  public enum State
  {
    WALKING,
    PAUSED,
    DIALOG
  }

  public State CurrentState;
}