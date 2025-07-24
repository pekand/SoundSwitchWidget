using System;
using System.Runtime.InteropServices;

namespace SoundSwitchWidget
{
    [ComImport]
    [Guid("F8679F50-850A-41CF-9C72-430F290290C8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IPolicyConfig
    {
        int GetMixFormat(string pszDeviceName, out IntPtr ppFormat);
        int GetDeviceFormat(string pszDeviceName, int bDefault, out IntPtr ppFormat);
        int ResetDeviceFormat(string pszDeviceName);
        int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr pMixFormat);
        int GetProcessingPeriod(string pszDeviceName, int bDefault, out long pmftDefault, out long pmftMinimum);
        int SetProcessingPeriod(string pszDeviceName, long pmftPeriod);
        int GetShareMode(string pszDeviceName, out IntPtr pMode);
        int SetShareMode(string pszDeviceName, IntPtr mode);
        int GetPropertyValue(string pszDeviceName, ref PROPERTYKEY key, out PROPVARIANT pv);
        int SetPropertyValue(string pszDeviceName, ref PROPERTYKEY key, ref PROPVARIANT pv);
        int SetDefaultEndpoint(string pszDeviceId, ERole role);
        int SetEndpointVisibility(string pszDeviceId, int bVisible);
    }

    [ComImport]
    [Guid("870AF99C-171D-4F9E-AF0D-E63DF40C2BC9")]
    class PolicyConfigClient
    {
    }

    enum ERole
    {
        eConsole = 0,
        eMultimedia = 1,
        eCommunications = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    struct PROPERTYKEY
    {
        public Guid fmtid;
        public int pid;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct PROPVARIANT
    {
        public ushort vt;
        public ushort wReserved1;
        public ushort wReserved2;
        public ushort wReserved3;
        public IntPtr p;
        public int p2;

        public static PROPVARIANT FromBoolean(bool val)
        {
            var pv = new PROPVARIANT();
            pv.vt = 11; // VT_BOOL
            pv.p = (IntPtr)(val ? -1 : 0);
            return pv;
        }
    }

    public static class AudioDeviceSwitcher
    {
        public static void SetDefaultDevice(string deviceId)
        {
            var policyConfig = (IPolicyConfig)new PolicyConfigClient();
            int hr = policyConfig.SetDefaultEndpoint(deviceId, ERole.eMultimedia);
            if (hr != 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }
}