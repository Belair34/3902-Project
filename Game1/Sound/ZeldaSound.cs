using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Game1.Sound
{
    public class ZeldaSound
    {
        private bool mute = false;
        private static ZeldaSound instance = new ZeldaSound();
        private Song music;
        public List<SoundEffect> soundEffects;

        public static ZeldaSound Instance
        {
            get
            {
                return instance;
            }
        }

        public bool Mute
        {
            get => mute;
            set => mute = value;
        }

        private ZeldaSound()
        {

        }

        public void LoadSound(ContentManager content)
        {
            music = content.Load<Song>("Sound/music");
            soundEffects = new List<SoundEffect>();
            soundEffects.Add(content.Load<SoundEffect>("Sound/EnemyDie"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/HitBoss"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/LinkDie"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/Boomerang"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/BombBlowup"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/DropBomb"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/PickupHeart"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/PickupRupee"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/ShootSword"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/SwordSlash"));
            soundEffects.Add(content.Load<SoundEffect>("Sound/TakeDamage"));

        }

        public void PlayMusic()
        {
            if(!Mute)
            {
                MediaPlayer.Play(music);
                MediaPlayer.IsRepeating = true;
            }
            
        }
        public void ChangeVolume(float vol)
        {
            MediaPlayer.Volume = vol;
        }

        public void TakeDamage()
        {
            if(!Mute)
            {
                soundEffects[10].Play();
            }
        }
        public void DropBomb()
        {
            if (!Mute)
            {
                soundEffects[5].Play();
            }
        }
        public void BombExplode()
        {
            if (!Mute)
            {
                soundEffects[4].Play();
            }
        }
        public void BoomerangThrow()
        {
            if (!Mute)
            {
                soundEffects[3].Play();
            }
        }
        public void SwordBeam()
        {
            if (!Mute)
            {
                soundEffects[8].Play();
            }
        }
        public void Sword()
        {
            if (!Mute)
            {
                soundEffects[9].Play();
            }
        }
        public void ShootArrow()
        {
            if (!Mute)
            {
                soundEffects[3].Play();
            }
        }


    }
}
