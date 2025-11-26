using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSwitchWidget
{
    public class AdvancedAudioMonitor : IDisposable
    {
        private readonly MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
        private MMDevice _currentDevice;


        private readonly Action _onDeviceChangeCallback;
        private readonly Action _onVolumeChangeCallback;

        public AdvancedAudioMonitor(
            Action onDeviceChange,
            Action onVolumeChange)
        {
            _onDeviceChangeCallback = onDeviceChange;
            _onVolumeChangeCallback = onVolumeChange;

            _deviceEnumerator.RegisterEndpointNotificationCallback(new AudioNotificationClient(OnDefaultDeviceChangedInternal));

            InitializeDevice();
        }


        private class AudioNotificationClient : IMMNotificationClient
        {
            private readonly Action<string, DataFlow> _callback;

            public AudioNotificationClient(Action<string, DataFlow> callback)
            {
                _callback = callback;
            }

            public void OnDefaultDeviceChanged(DataFlow flow, Role role, string deviceId)
            {
                if (role == Role.Console)
                {
                    _callback(deviceId, flow);
                }
            }

            public void OnDeviceStateChanged(string deviceId, DeviceState newState) { }
            public void OnDeviceAdded(string deviceId) { }
            public void OnDeviceRemoved(string deviceId) { }
            public void OnPropertyValueChanged(string deviceId, PropertyKey key) { }
        }


        private void OnDefaultDeviceChangedInternal(string newDeviceId, DataFlow flow)
        {
            if (flow != DataFlow.Render) return; 

            if (_currentDevice != null)
            {
                _currentDevice.AudioEndpointVolume.OnVolumeNotification -= OnVolumeNotification;
            }


            InitializeDevice(newDeviceId);
            _onDeviceChangeCallback?.Invoke();
        }

        private void InitializeDevice(string deviceId = null)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                _currentDevice = _deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            }
            else
            {
                _currentDevice = _deviceEnumerator.GetDevice(deviceId);
            }

            _currentDevice.AudioEndpointVolume.OnVolumeNotification += OnVolumeNotification;
        }


        private void OnVolumeNotification(AudioVolumeNotificationData data)
        {
            _onVolumeChangeCallback?.Invoke();
        }

        public void Dispose()
        {
            if (_currentDevice != null)
            {
                _currentDevice.AudioEndpointVolume.OnVolumeNotification -= OnVolumeNotification;
                _currentDevice.Dispose();
            }

            _deviceEnumerator.UnregisterEndpointNotificationCallback(new AudioNotificationClient(OnDefaultDeviceChangedInternal));
            _deviceEnumerator.Dispose();
        }
    }
}
