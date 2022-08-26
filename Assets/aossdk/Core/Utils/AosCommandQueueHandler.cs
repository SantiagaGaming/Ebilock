using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class AosCommandQueueHandler : MonoBehaviour
    {
        [SerializeField] private AosSDKSettings sdkSettings;
        public CommandList<AosCommand> CommandQueue { get; } = new CommandList<AosCommand>();

        private void Start()
        {
            CommandQueue.OnItemAdded += CommandQueueOnOnItemAdded;
        }

        private void CommandQueueOnOnItemAdded(AosCommand command)
        {
            if (command == null)
            {
                return;
            }

            var aosObjectToExecuteCommandOn = AosObjectFind.FindAosObjectById(RuntimeData.Instance.AosObjects, command.objectId);

            if (aosObjectToExecuteCommandOn)
            {
                aosObjectToExecuteCommandOn.QueueCommand(command);

                CommandQueue.Remove(command);
                
                return;
            }

            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageError
            {
                objectId = null,
                type = ServerMessageType.Error.ToString(),
                errorMessage = $"Object with guid {command.objectId} not found on scene"
            });
        }
    }
}