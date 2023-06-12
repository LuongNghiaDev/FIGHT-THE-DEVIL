using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundGun", menuName = "SoundGun")]
public class SoundGun : ScriptableObject
{
    public new string name;
    public AudioClip weaponSound;
}
