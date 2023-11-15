using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AosSdk.Core.Utils.AosObjectBase;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Коннект")]
public class ConnectionToClient : AosObjectBase
{
    [SerializeField] private WebSocketWrapper _wrapper;
    [AosEvent(name: "Ready to connect")]
    public event AosEventHandlerWithAttribute OnReadyToAction;

    private const string READY_TO_ACTION = "Ready to Action";
    private void Start() => _wrapper.OnClientConnected += OnReadyToConnect;
    private void OnReadyToConnect() => OnReadyToAction.Invoke(READY_TO_ACTION);
}
