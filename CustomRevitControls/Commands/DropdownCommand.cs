﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomRevitControls.Commands
{
    public class DropdownCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ControlsContext viewModel;
        public DropdownCommand(ControlsContext vm)=> viewModel = vm;


        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var paramArray = parameter as object[];
            IEnumerable items = (IEnumerable)paramArray[0];
            FrameworkElement btn = (FrameworkElement)paramArray[1];
            RevitControl SplitItem = null;
            if (paramArray.Length == 3)
                SplitItem = (RevitControl)paramArray[2];

            //Window win = (Window)(parameter as object[])[1];
            Window win = Window.GetWindow(btn);

            Point startPoint = btn.TranslatePoint(new Point(0, 0), win);//.TransformToAncestor(win).Transform(new Point(0, 0));
            var p = win.PointToScreen(startPoint);
            Dropdown ui = new Dropdown(SplitItem);
            ui.Droplist.ItemsSource = items;
            ui.WindowStartupLocation = WindowStartupLocation.Manual;
            ui.Left = p.X;
            ui.Top = p.Y + btn.ActualHeight + 2;
            ui.Show();
        }
    }
}