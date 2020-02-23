using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public static readonly Settings Instance = new Settings();

    private bool sound, vibration;

    public bool Sound { get => sound; set => sound = value; }
    public bool Vibration { get => vibration; set => vibration = value; }
}