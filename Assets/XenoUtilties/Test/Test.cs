﻿using UnityEngine;
using Xeno.Utilities;

namespace Xeno.Utilties.Test
{
    public class Test
    {
        public void Main()
        {
            Vector3 a = new Vector3(1, 1, 1);
            Vector2 b = a.Vec2xz();
        }
    }
}