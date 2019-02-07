using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UnityChatScript
{
    public class ChatScriptAPI
    {
        [DllImport("chatscript")]
        public static extern uint chatscript_init_sys(int argc, string[] argv, string unchangedPath, string readonlyPath, string writablePath);

        [DllImport("chatscript")]
        public static extern void chatscript_perform_chat(string user, string usee, string incoming, string ip, [MarshalAs(UnmanagedType.LPStr)]StringBuilder buffer);

        [DllImport("chatscript")]
        public static extern void chatscript_close();
    }

    public class ChatScript : MonoBehaviour
    {
        private void Start()
        {
            var path = Application.streamingAssetsPath + "/chatscript";
            if (ChatScriptAPI.chatscript_init_sys(0, new string[] { }, path, path, path) != 0)
            {
                Debug.LogError("Failed to initialize chatscript system!");
            }
        }

        public string Query(string text, string username, string botName)
        {
            StringBuilder buffer = new StringBuilder(1024);
            ChatScriptAPI.chatscript_perform_chat(username, botName, text, "0.0.0.0", buffer);

            return buffer.ToString();
        }
    }
}