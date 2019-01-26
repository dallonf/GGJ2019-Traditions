using UnityEngine;

public interface ISingleton { }

public static class Singleton
{
  public static T GetInstance<T>() where T : MonoBehaviour, ISingleton
  {
    var found = Object.FindObjectOfType<T>();
    if (found) return found;

    var type = typeof(T);
    var obj = new GameObject("_" + type.Name, type);
    return obj.GetComponent<T>();
  }
}