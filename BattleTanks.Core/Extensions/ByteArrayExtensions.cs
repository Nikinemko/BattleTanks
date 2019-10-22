﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Core.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ToRenderablePictureString(this byte[] array)
        {
            if (array == null)
            {
                return string.Empty;
            }
            return "data:image; base64," + Convert.ToBase64String(array);
        }
    }
}
