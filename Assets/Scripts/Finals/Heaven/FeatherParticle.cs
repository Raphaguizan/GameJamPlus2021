using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Finals.Heaven
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FeatherParticle : MonoBehaviour
    {
        private ParticleSystem particles;
        private Transform chicken;

        private void Start()
        {
            particles = GetComponent<ParticleSystem>();
            chicken = GameObject.FindObjectOfType<Chicken.Chicken>().transform;
        }

        public void Play()
        {
            transform.position = chicken.position;
            particles.Play();
        }
    }
}