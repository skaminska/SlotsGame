using SlotsGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Threading;

namespace SlotsGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int playerMoney;
        List<ElementsOnRolls> roll;
        DispatcherTimer timer;
        Random random = new Random();
        int win;
        public MainWindow()
        {
            InitializeComponent();

            playerMoney = 15;

            roll = new List<ElementsOnRolls> 
            {
                new ElementsOnRolls("!", 5),
                new ElementsOnRolls("b", 10),
                new ElementsOnRolls("Y", 15),
                new ElementsOnRolls("e", 20),
                new ElementsOnRolls("%", 25),
            };

            Money.Content = "Pieniądze: " + playerMoney.ToString();

            timer = new DispatcherTimer();
            timer.Tick += updateLabels_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }



        private void updateLabels_Tick(object sender, EventArgs e)
        {
            
            TimeSpan diff = new TimeSpan(0, 0, 0, 0, 30);
            TimeSpan roll1Stop = new TimeSpan(0, 0, 0, 0, 100);
            TimeSpan roll2Stop = roll1Stop + diff;
            TimeSpan roll3Stop = roll2Stop + diff;

            timer.Interval += new TimeSpan(0, 0, 0, 0, 5);

            int element1 = random.Next(roll.Count); ;
            int element2 = random.Next(roll.Count); ;
            int element3 = random.Next(roll.Count); ;
            if (timer.Interval < roll1Stop)
            {
                rolka1.Content = roll[element1].Symbol.ToString();
                rolka2.Content = roll[element2].Symbol.ToString();
                rolka3.Content = roll[element3].Symbol.ToString();
            }
            else if (timer.Interval < roll2Stop)
            {
                rolka2.Content = roll[element2].Symbol.ToString();
                rolka3.Content = roll[element3].Symbol.ToString();
            }
            else if (timer.Interval < roll3Stop)
            {
                rolka3.Content = roll[element3].Symbol.ToString();
                win = roll[element3].Value;
            }
            else
            {
                LetsRoll.IsEnabled = true;
                timer.Stop();
                CheckIfWin(win);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            }
        }

        private void CheckIfWin(int i)
        {
            if(rolka1.Content == rolka2.Content && rolka2.Content == rolka3.Content)
            {
                int win = i;
                playerMoney +=  win;
                Money.Content = "Pieniądze: " + playerMoney.ToString();
                LastWin.Content = "Ostatnia wygrana: " + win.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(playerMoney>0)
            {
                timer.Start();
                playerMoney--;
                Money.Content = "Pieniądze: " + playerMoney.ToString();
                LetsRoll.IsEnabled = false;
            }
            else
            {
                System.Windows.MessageBox.Show("Brak środków", "Koniec gry");
            }
        }
    }
}
