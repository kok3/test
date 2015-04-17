﻿using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public class stChannelChatUserCmd : stNullUserCmd
{
    public uint dwType;
    public uint dwSysInfoType;
    public uint dwCharType;
    public uint dwChannelID;
    public uint dwFromID;
    public uint dwChatTime;
    public byte size;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x20)]
    public string pstrName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x100)]
    public string pstrChat;
    public uint dwThisID;
    public stChannelChatUserCmd()
    {
        base.byCmd = 14;
        base.byParam = 1;
        this.dwType = 12;
        this.dwChannelID = 0;
        this.dwSysInfoType = 0;
        this.dwCharType = 1;
        this.dwThisID = 0;
        this.size = 0;
        this.dwChatTime = 0;
    }
}
