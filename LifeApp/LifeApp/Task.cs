using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Task {
    public string taskName { get; set; }
    public DateTime dueDate { get; set; }
}

public class TaskList : List<Task> {
    public ObservableCollection<Task> taskList;

    public void AddTask(string taskName, DateTime dueDate) {
        if (taskList == null) {
            taskList = new ObservableCollection<Task>();
        }

        taskList.Add(new Task() {
            taskName = taskName,
            dueDate = dueDate
        });
    }

    public void RemoveTask(Task item) {
        taskList.Remove(item);
    }

    public ObservableCollection<Task> getList() {
        return taskList;
    }
}