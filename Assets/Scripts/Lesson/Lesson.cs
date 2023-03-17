using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour
{
    public List<Texture> slides;
    public List<AudioClip> explanations;
    public RawImage actualSlide;
    public AudioSource sound;

    private int _actualSlideIndex;

    public void ButtonPressed()
    {
        if (sound.isPlaying)
        {
            CancelInvoke();
            Rewind();
        }
        else
        {
            CancelInvoke();
            Rewind();
            Explain();
        }
    }

    private void Next()
    {
        if (_actualSlideIndex < slides.Count -1)
        {
            _actualSlideIndex++;
            actualSlide.texture = slides[_actualSlideIndex];
            Explain();
        }
        else
        {
            actualSlide.color = Color.clear;
        }
    }
    
    private void Rewind()
    {
        sound.Stop();
        actualSlide.color = Color.clear;
        _actualSlideIndex = 0;
        actualSlide.texture = slides[_actualSlideIndex];
    }
    
    private void Explain()
    {
        actualSlide.color = Color.white;
        sound.clip = explanations[_actualSlideIndex];
        sound.Play();
        Invoke(nameof(Next), sound.clip.length +0.5f);
    }
}
