using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace SoundSwitchWidget
{
    public class VolumeController
    {
        private MMDeviceEnumerator deviceEnumerator = null;
        private MMDevice defaultDevice = null;

        public VolumeController()
        {
            SetCurrentDevice();
        }
      
        public void SetCurrentDevice()
        {
            deviceEnumerator = new MMDeviceEnumerator();
            defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        // Get volume 0-100
        public int GetVolume()
        {
            return (int)(defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }

        // Set volume 0-100
        public void SetVolume(int volumePercent)
        {        
            if (volumePercent < 0) volumePercent = 0;
            if (volumePercent > 100) volumePercent = 100;

            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumePercent / 100f;
        }
    }
}
