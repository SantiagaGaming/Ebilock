using AosSdk.Core.Utils;
using UnityEngine;
using System.Threading;
[AosSdk.Core.Utils.AosObject(name: "Коннект")]
public class ConnectionToClient : AosObjectBase
{
    [SerializeField] private WebSocketWrapper _wrapper;
    [AosEvent(name: "Ready to connect")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    [SerializeField] private string _firstLocation;

    private const string READY_TO_ACTION = "Ready to Action";
    private void Start() => _wrapper.OnClientConnected += OnReadyToConnect;
    private void OnReadyToConnect() 
    {
        Thread.Sleep(2000);
        OnReadyToAction.Invoke(READY_TO_ACTION);
        Thread.Sleep(2000);
        API.Instance.ConnectionEstablished(_firstLocation);
    }
}
