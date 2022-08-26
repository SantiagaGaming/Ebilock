using System.Collections.Generic;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class RuntimeData : MonoBehaviour
    {
        public static RuntimeData Instance { get; private set; }

        public List<AosObjectBase> AosObjects { get; } = new List<AosObjectBase>();

        private void OnEnable()
        {
            Instance ??= this;
        }
    }
}