using System;
using System.Collections.Generic;
using System.Text;

namespace Overguide.Services
{
    public interface AudioInterface
    {
        void SetUpAudio();

        void Play();

        void Pause();

        void Restart();

        void RemoveNotification();

        object playerCurrettime();

        object getTotaltime();

        object MediaTotalDuration();

        event EventHandler positionChanged;
    }
}