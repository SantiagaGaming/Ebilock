using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
[AosSdk.Core.Utils.AosObject(name: "Амперметр")]
public class SetTextAOSObject : AosObjectBase
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [AosAction("Задать текст отказа")]
    public void SetOtkazText([AosParameter("Задать Текст")] string text)
    {
        _textMesh.text = text;
    }

}
