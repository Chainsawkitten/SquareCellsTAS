using System;
using UnityEngine;

namespace SquareCellsTAS
{
    class FrameCounter : MonoBehaviour
    {
        public int frameCount = 0;

        public void Start()
        {
            
        }
        public void Update()
        {
            frameCount += 1;
        }
    }
}
