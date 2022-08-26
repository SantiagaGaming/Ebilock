using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonActionInvoker : SceneAosObject
{
    [SerializeField]private TextMeshProUGUI _text;

    public override void SetObjectName([AosParameter("Задать Текст")] string text)
    {
      _text.text = text;
    }
}
