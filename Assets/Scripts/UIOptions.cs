using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider shootingVolumeSlider;
    public Slider damageVolumeSlider;
    AudioPlayer audioPlayer;

    void Start()
	{
        audioPlayer = FindObjectOfType<AudioPlayer>();

        musicVolumeSlider.value = AudioListener.volume;
        shootingVolumeSlider.value = audioPlayer.GetShootingClipVolume();
        damageVolumeSlider.value = audioPlayer.GetDamageClipVolume();

		musicVolumeSlider.onValueChanged.AddListener (delegate {MusicVolumeValueChange();});
		shootingVolumeSlider.onValueChanged.AddListener (delegate {ShootingVolumeValueChange();});
		damageVolumeSlider.onValueChanged.AddListener (delegate {DamageVolumeValueChange();});
	}
	
	public void MusicVolumeValueChange()
	{
        AudioListener.volume = musicVolumeSlider.value;
	}

    public void ShootingVolumeValueChange()
	{
        audioPlayer.SetShootingClipVolume(shootingVolumeSlider.value);
	}

    public void DamageVolumeValueChange()
	{
        audioPlayer.SetDamageClipVolume(damageVolumeSlider.value);
	}
}
