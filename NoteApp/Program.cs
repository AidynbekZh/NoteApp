using System;
using System.Collections.Generic;

class TaskManager
{
    class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

    static List<Task> tasks = new List<Task>();
    static int currentId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Менеджер задач:\n" +
                              "1. Добавить задачу\n" +
                              "2. Показать все задачи\n" +
                              "3. Удалить задачу\n" +
                              "4. Завершить задачу\n" +
                              "5. Выход");

            int choice = GetChoice(1, 5);

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ShowTasks();
                    break;
                case 3:
                    DeleteTask();
                    break;
                case 4:
                    CompleteTask();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Введите название задачи: ");
        string name = Console.ReadLine();

        Task newTask = new Task { Id = currentId++, Name = name, IsCompleted = false };
        tasks.Add(newTask);

        Console.WriteLine("Задача добавлена.");
    }

    static void ShowTasks()
    {
        Console.WriteLine("Список задач:");

        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "[Выполнено] " : "";
            Console.WriteLine($"{task.Id}. {status}{task.Name}");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Введите ID задачи для удаления: ");
        int taskId = GetTaskId();

        Task taskToRemove = tasks.Find(t => t.Id == taskId);

        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            Console.WriteLine("Задача удалена.");
        }
        else
        {
            Console.WriteLine("Задача не найдена.");
        }
    }

    static void CompleteTask()
    {
        Console.Write("Введите ID задачи для завершения: ");
        int taskId = GetTaskId();

        Task taskToComplete = tasks.Find(t => t.Id == taskId);

        if (taskToComplete != null)
        {
            taskToComplete.IsCompleted = true;
            Console.WriteLine("Задача завершена.");
        }
        else
        {
            Console.WriteLine("Задача не найдена.");
        }
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.Write($"Введите корректное значение от {min} до {max}: ");
        }
        return choice;
    }

    static int GetTaskId()
    {
        int taskId;
        while (!int.TryParse(Console.ReadLine(), out taskId) || taskId <= 0)
        {
            Console.Write("Введите корректный положительный ID: ");
        }
        return taskId;
    }
}

