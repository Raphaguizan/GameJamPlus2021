using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Util.LightRandom
{
    [RequireComponent(typeof(Light))]
    public class RandomLightChange : MonoBehaviour
    {
        [SerializeField]
        private Vector2 randomTime;
        [SerializeField]
        private List<Color> colorList;

        private Light myLight;
        private float currentTime;
        void Start()
        {
            myLight = GetComponent<Light>();
            currentTime = 0;
        }

        void Update()
        {
            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                myLight.color = RandomColor();
                currentTime = RandomTime();
            }
        }
        private float RandomTime()
        {
            return Random.Range(randomTime.x, randomTime.y);
        }
        private Color RandomColor()
        {
            return colorList[Random.Range(0, colorList.Count - 1)];
        }
    }
}