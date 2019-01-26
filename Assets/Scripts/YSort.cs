using UnityEngine;

public class YSort : MonoBehaviour
{

  private SpriteRenderer spriteRenderer;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
  }
}