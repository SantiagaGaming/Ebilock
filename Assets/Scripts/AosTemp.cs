using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[AosSdk.Core.Utils.AosObject(name: "Temp text")]
public class AosTemp : AosObjectBase
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [AosAction(name: "Задать текст измерения")]
    public void SetTempText(string text)
    {
        
        _textMesh.text = HtmlToText.Instance.HTMLToTextReplace(text);
    }
}