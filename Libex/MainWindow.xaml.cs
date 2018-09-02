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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Libex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //dispatcher timer variable for the slideshow 
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        //image number for the slide show 
        private int imageNumber = 1;

        public MainWindow()
        {
            InitializeComponent();

        }


        // open menu click event
        private void openMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            closeMenuBtn.IsChecked = true;
        }

        //close menu click event
        private void closeMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            openMenuBtn.IsChecked = false;
        }

        //exit application button click
        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //max application button click
        private void maxAppBtn_Click(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.WindowState = WindowState.Maximized;
            maxAppBtn.Visibility = Visibility.Collapsed;
            restoreAppBtn.Visibility = Visibility.Visible;
        }
        //show the restore down button on top of the window when it is maximized without the max button
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                restoreAppBtn.Visibility = Visibility.Visible;
                maxAppBtn.Visibility = Visibility.Collapsed;
            }
        }


        //restore minimize window
        private void restoreAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            restoreAppBtn.Visibility = Visibility.Collapsed;
            maxAppBtn.Visibility = Visibility.Visible;
        }

        //turns the open menu button unchecked 
        private void DrawerHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            openMenuBtn.IsChecked = false;
        }

        //left mouse clicked on the top color zone event
        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //minimize button click event
        private void minAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void tealAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/TealAmberTheme.xaml");
        }

        private void blueGreyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
        }


        private void blueAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueAmberTheme.xaml");
        }

        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        //adding the tab created from the user control to the tabControl in the main window
        private void myTab_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalVariables.tbControl = (sender as TabControl);
        }


        //method that shows which menu item is selected
        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //the selected item
            int listItemSelectedIndex = MenuList.SelectedIndex;
            MoveCursorMenu(listItemSelectedIndex);

            //changing the user controls on list item clicks
            switch (listItemSelectedIndex)
            {
                case 0:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new DashBoardUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 1:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new statisticsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 2:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new ClientsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 3:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new bookUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 4:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new OrdersUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 5:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new ReturnedBooksUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 6:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new SellsAndRentsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 7:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new SettingsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                default:
                    break;
            }
        }

        //method that moves the cursor on the menu based on selection 
        private void MoveCursorMenu(int listItemSelectedIndex)
        {
            //transitioningContentSlide.OnApplyTemplate();
            MenuCursor.Margin = new Thickness(0, (117.5 + (50 * listItemSelectedIndex)), 0, 0);
        }

        //window size event , it changes the size of the tab control based on the window size 
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                tabControlDragable.Width = 1920;

            }
            else
            {
                tabControlDragable.Width = this.Width;
            }
        }

        //dispatcher time of the image slide show initializing 
        private void DispatcherTimerSlideShow()
        {
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Start();

        }

        //changing images in every tick of the dispatcher timer 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            loadNextImage();
        }

        //activatin the slideshow when the expander is expended 
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSlideShow();
        }

        //stopping the slideshow when the expander is collapsed
        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            dispatcher.Stop();
        }

        //loading the next image 
        private void loadNextImage()
        {
            if (imageNumber == 4)
            {
                imageNumber = 1;
            }
            string temp = string.Format(@"Resources\{0}.jpg", imageNumber);
            BitmapImage img = new BitmapImage(new Uri(temp, UriKind.Relative));
            
            img.UriSource = new Uri(temp, UriKind.Relative);          
            SlideShowImageContainer.Source = new BitmapImage(new Uri(temp, UriKind.Relative));
            imageNumber++;
        }

        //get started button event in the WELCOME expander
        private void getStartedBtn_Click(object sender, RoutedEventArgs e)
        {
            openMenuBtn.Command.Execute(openMenuBtn.Command);

        }
    }
}
