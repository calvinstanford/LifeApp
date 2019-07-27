using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LifeApp {
    public partial class MainPage : ContentPage {
        public static string taskType;

        private string userName = "Bob";

        private void taskAdded(object sender, EventArgs e)
        {
            Entry entry = sender as Entry;
            var text = entry.Text;

            Navigation.PushAsync(new Pages.AddTask(text));
        }

        private void viewAllTasks(object sender, EventArgs e) {
            Navigation.PushAsync(new Pages.ViewTasks());
        }

        private void EditAvatar(object sender, EventArgs e) {
            Navigation.PushAsync(new Pages.Customize());
        }

        async void levelUp(object sender, EventArgs args) {
            Label name = this.FindByName<Label>("username");
            Label levelLabel = this.FindByName<Label>("userLevel");

            ProgressBar levelBar = this.FindByName<ProgressBar>("userLevelBar");
            ProgressBar physBar = this.FindByName<ProgressBar>("physicalBar");
            ProgressBar mentBar = this.FindByName<ProgressBar>("mentalBar");
            ProgressBar socBar = this.FindByName<ProgressBar>("socialBar");
            ProgressBar financeBar = this.FindByName<ProgressBar>("financialBar");

            taskType = "Physical";

            await levelBar.ProgressTo(levelBar.Progress + .2, 250, Easing.Linear);
            double progression_main = 0.15;
            double progression_sub = 0.05;
            double progression_calc = 0.0;

            if (taskType == "Physical") {
                if (physBar.Progress >= 0.85) {
                    progression_main = 1.0 - physBar.Progress;
                    progression_sub = progression_main / 3;
                }

                if(mentBar.Progress <=progression_sub) {
                    progression_calc = progression_sub - mentBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (socBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - socBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (financeBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - financeBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                await mentBar.ProgressTo(mentBar.Progress - progression_sub, 100, Easing.Linear);
                await socBar.ProgressTo(socBar.Progress - progression_sub, 100, Easing.Linear);
                await financeBar.ProgressTo(financeBar.Progress - progression_sub, 100, Easing.Linear);
                await physBar.ProgressTo(physBar.Progress + progression_main, 100, Easing.Linear);   
            } else if (taskType == "Mental") {
                if (mentBar.Progress >= 0.85) {
                    progression_main = 1.0 - mentBar.Progress;
                    progression_sub = progression_main / 3;
                }

                if (physBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - physBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (socBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - socBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (financeBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - financeBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                await physBar.ProgressTo(physBar.Progress - progression_sub, 100, Easing.Linear);
                await socBar.ProgressTo(socBar.Progress - progression_sub, 100, Easing.Linear);
                await financeBar.ProgressTo(financeBar.Progress - progression_sub, 100, Easing.Linear);
                await mentBar.ProgressTo(mentBar.Progress + progression_main, 100, Easing.Linear);
            } else if (taskType == "Social") {
                if (socBar.Progress >= 0.85) {
                    progression_main = 1.0 - socBar.Progress;
                    progression_sub = progression_main / 3;
                }

                if (mentBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - mentBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (physBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - physBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (financeBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - financeBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                await mentBar.ProgressTo(mentBar.Progress - progression_sub, 100, Easing.Linear);
                await physBar.ProgressTo(physBar.Progress - progression_sub, 100, Easing.Linear);
                await financeBar.ProgressTo(financeBar.Progress - progression_sub, 100, Easing.Linear);
                await socBar.ProgressTo(socBar.Progress + progression_main, 100, Easing.Linear);
            } else {
                if (financeBar.Progress >= 0.85) {
                    progression_main = 1.0 - financeBar.Progress;
                    progression_sub = progression_main / 3;
                }

                if (mentBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - mentBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (socBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - socBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                if (physBar.Progress <= progression_sub) {
                    progression_calc = progression_sub - physBar.Progress;
                    progression_sub = progression_sub + (progression_calc / 2);
                }

                await mentBar.ProgressTo(mentBar.Progress - progression_sub, 100, Easing.Linear);
                await socBar.ProgressTo(socBar.Progress - progression_sub, 100, Easing.Linear);
                await physBar.ProgressTo(physBar.Progress - progression_sub, 100, Easing.Linear);
                await financeBar.ProgressTo(financeBar.Progress + progression_main, 100, Easing.Linear);
            }

            if ((int)levelBar.Progress == 1) {
                //name.Text = "Level Up!";
                await DisplayAlert("Level Up!", null, "OK");

                int convertLevelInt = Convert.ToInt32(levelLabel.Text);
                convertLevelInt++;

                String convertLevelString = Convert.ToString(convertLevelInt);
                levelLabel.Text = convertLevelString;

                await levelBar.ProgressTo(0, 250, Easing.Linear);

                name.Text = userName;
            }
        }

        public MainPage()
        {   
            InitializeComponent();

            Label name = this.FindByName<Label>("username");
            name.Text = userName;
        }
    }
}