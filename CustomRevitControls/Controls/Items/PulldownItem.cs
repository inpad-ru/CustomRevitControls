﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomRevitControls
{
    public class PulldownItem : RevitControl
    {

        public override string ControlName => GetType().Name;
        public override bool HasElements => false;

        public PulldownItem(object text, string iconPath)
        {
            Content = text;
            MainIcon = GetImageSource(iconPath);
        }
    }
}