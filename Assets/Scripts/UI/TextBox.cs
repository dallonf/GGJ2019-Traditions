using System.Collections;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{

  public TextMeshProUGUI textMesh;

  public IEnumerator ShowText(string text)
  {
    textMesh.text = text;
    while (!Input.GetButtonDown("Interact")) {
      // wait for user to close text box
      yield return null;
    }
  }
}