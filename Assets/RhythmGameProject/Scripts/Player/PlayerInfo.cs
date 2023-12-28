using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary> プレイヤーの情報を保持するクラス </summary>
public class PlayerInfo
{
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public int PlayerExp { get; set; }
    public int PlayerMoney { get; set; }
    public int PlayerStamina { get; set; }
    public PlayerSettings Settings { get; set; }

    public PlayerInfo()
    {
        Settings = new PlayerSettings();
    }

    /// <summary> プレイヤーが設定できる設定値を保持するクラス </summary>
    public class PlayerSettings
    {
        public float NotesSpeed { get; set; } = 10.0f;
        public float JudgeOffset { get; set; } = 0.0f;
        public float MasterVolume { get; set; } = 1.0f;
        public float BGMVolume { get; set; } = 1.0f;
        public float SEVolume { get; set; } = 1.0f;
        public float VoiceVolume { get; set; } = 1.0f;
        public bool ShowFPS { get; set; } = true;
    }
}