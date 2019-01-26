using System.Collections;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{

  public TextMeshProUGUI textMesh;

  public IEnumerator ShowText(string text)
  {
    textMesh.text = text;
    yield return new WaitForSeconds(1f);
  }
}