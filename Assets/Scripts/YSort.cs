using UnityEngine;

public class YSort : MonoBehaviour
{
  void Update()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
  }
}