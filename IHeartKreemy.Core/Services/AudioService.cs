using System.Media;

namespace IHeartKreemy.Core.Services
{
    public class AudioService
    {
        private SoundPlayer _soundPlayer;

        public AudioService(string soundFilePath)
        {
            _soundPlayer = new SoundPlayer(soundFilePath);
        }

        public void PlayCreamySound()
        {
            _soundPlayer.Play();
        }
    }
}
