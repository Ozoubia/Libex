﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;



namespace Libex
{
    /// <summary>
    /// Interaction logic for globalSettingUserControl.xaml
    /// </summary>
    public partial class globalSettingUserControl : UserControl
    {
        public globalSettingUserControl()
        {
            
            InitializeComponent();
        }

       

        //adding a resource dictionnary 
        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            
        }
     

        private void blueBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Blue";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            
        }

        private void tealBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Resources.MergedDictionaries.Clear();             
            AddResourceDictionary("Resources/TealAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Green";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        private void blueGBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Gray";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }
        
        
    }
}
