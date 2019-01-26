using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{

  public TextMeshProUGUI textMesh;
  public Image nextIcon;
  public float CharacterDelay = 0.05f;

  public IEnumerator ShowText(string text)
  {
    nextIcon.enabled = false;
    for (int i = 0; i < text.Length; i++)
    {
      // try to skip formatting tags
      // this isn't particularly robust but it should be good enough for now
      if (text[i] == '<')
      {
        var closingBracket = text.IndexOf('>', i);
        i = closingBracket;
        continue;
      }
      textMesh.text = text.Substring(0, i);
      yield return new WaitForSecondsRealtime(CharacterDelay);
    }
    textMesh.text = text;
    nextIcon.enabled = true;
    while (!Input.anyKeyDown)
    {
      // wait for user to close text box
      yield return null;
    }
  }
}