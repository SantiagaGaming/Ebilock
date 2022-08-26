using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Текст Локации")]
public class LocationController : AosObjectBase
{
    [SerializeField] private TextMeshProUGUI _deskText;
    [SerializeField] private TextMeshProUGUI _textMesh;
    private void Start()
    {
        _deskText.text = "Поле";
        _textMesh.text = "Поле";
    }
    [AosAction("Задать имя объекта")]
    public void SetLocationText([AosParameter("Задать Текст")] string location)
    {
        _deskText.text = location;
        _textMesh.text = location;
    }


}
