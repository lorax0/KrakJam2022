using System;
using System.Collections;
using UnityEngine;

namespace KrakJam2022
{
    [Serializable]
    public class Timer
    {
        public Action OnTimeEnd;
        public Action OnTimeUpdate;
        [SerializeField] protected float time;

        public void UpdateTimer()
        {
            if (this.time <= 0)
            {
                this.OnTimeEnd?.Invoke();
                return;
            }
            this.time -= Time.deltaTime;
            this.OnTimeUpdate?.Invoke();
        }
    }
}