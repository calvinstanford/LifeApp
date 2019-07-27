using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LifeApp.Pages {
    public partial class AddTask : ContentPage {
        private ViewTasks viewList = new ViewTasks();

        private async void SaveTask(object sender, EventArgs e) {
            Entry editEntry = this.FindByName<Entry>("editTaskEntry");
            DatePicker taskDate = this.FindByName<DatePicker>("taskDueDate");
            Picker type = this.FindByName<Picker>("taskType");
            string typeName = type.Items[type.SelectedIndex];

            viewList.SetTasks(editEntry.Text, taskDate.Date, typeName);
            await DisplayAlert("Success!", "Your task has been saved!", "Okay");
            await Navigation.PopAsync();
        }

        public AddTask() {
            InitializeComponent();
        }

        public AddTask(string text) {
            InitializeComponent();
            Entry addTaskEntry = this.FindByName<Entry>("editTaskEntry");
            addTaskEntry.Text = text;
        }
    }
}