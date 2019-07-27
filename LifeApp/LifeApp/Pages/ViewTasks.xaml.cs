using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Android.Content;
using Android.Support.Design.Widget;
using Xamarin.Forms;

namespace LifeApp.Pages {
    public partial class ViewTasks : TabbedPage {
        public static TaskList taskList = new TaskList();
        public static TaskList physicalList = new TaskList();
        public static TaskList mentalList = new TaskList();
        public static TaskList socialList = new TaskList();
        public static TaskList financialList = new TaskList();

        public void SetTasks(string taskName, DateTime dueDate, string type) {
            taskList.AddTask(taskName, dueDate);

            if (type.Equals("Physical")) {
                physicalList.AddTask(taskName, dueDate);
            } else if (type.Equals("Mental")) {
                mentalList.AddTask(taskName, dueDate);
            } else if (type.Equals("Social")) {
                socialList.AddTask(taskName, dueDate);
            } else if (type.Equals("Financial")) {
                financialList.AddTask(taskName, dueDate);
            }
        }

        public async void OnCompleteAsync(object sender, EventArgs e) {
            var item = ((MenuItem)sender);
            Task selectedTask = (Task)item.CommandParameter;

            bool doComplete = await DisplayAlert("Are You Sure?", "Are you sure you want to delete this task?", "Yes", "No");

            if (doComplete) {
                taskList.RemoveTask(selectedTask);
                foreach (Task checkTask in physicalList.getList()) {
                    if (checkTask == selectedTask) {
                        physicalList.RemoveTask(selectedTask);
                    }
                }
            }
        }

        public ViewTasks() {
            InitializeComponent();

            ListView allTList = this.FindByName<ListView>("allTaskList");
            ListView phyTList = this.FindByName<ListView>("physicalTaskList");
            ListView menTList = this.FindByName<ListView>("mentalTaskList");
            ListView socTList = this.FindByName<ListView>("socialTaskList");
            ListView finTList = this.FindByName<ListView>("financialTaskList");

            allTList.BindingContext = taskList.getList();
            phyTList.BindingContext = physicalList.getList();
            menTList.BindingContext = mentalList.getList();
            socTList.BindingContext = socialList.getList();
            finTList.BindingContext = financialList.getList();
        }
    }
}