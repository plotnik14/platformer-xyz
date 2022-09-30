using UnityEngine;

namespace PixelCrew.Components.Audio
{
    public class PlayMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSource _source;

        public void Play()
        {
            _source.clip = _clip;
            _source.Play();
        }
    }
}
