using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
  public static LevelTransition Instance
  {
    get
    {
      return Singleton.GetExistingInstance<LevelTransition>();
    }
  }

  public Image FadeToBlackImage;
}