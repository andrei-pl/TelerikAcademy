using HW_CSharp;
using System;
using System.Collections.Generic;
using System.Text;

internal class Program
{
    private static StringBuilder output;

    private static EventHolder events;

    static Program()
    {
        Program.output = new StringBuilder();
        Program.events = new EventHolder();
    }

    public Program()
    {
    }

    private static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;
        Program.GetParameters(command, "AddEvent", out date, out title, out location);
        Program.events.AddEvent(date, title, location);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        Program.events.DeleteEvents(title);
    }

    private static bool ExecuteNextCommand()
    {
        bool flag;
        string command = Console.ReadLine();
        bool flag1 = command[0] != 'A';
        if (flag1)
        {
            flag1 = command[0] != 'D';
            if (flag1)
            {
                flag1 = command[0] != 'L';
                if (flag1)
                {
                    flag1 = command[0] != 'E';
                    flag = (flag1 ? false : false);
                }
                else
                {
                    Program.ListEvents(command);
                    flag = true;
                }
            }
            else
            {
                Program.DeleteEvents(command);
                flag = true;
            }
        }
        else
        {
            Program.AddEvent(command);
            flag = true;
        }
        return flag;
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        DateTime dateTime = date;
        return dateTime;
    }

    private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = Program.GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');
        bool flag = firstPipeIndex != lastPipeIndex;
        if (flag)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = "";
        }
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = Program.GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        Program.events.ListEvents(date, count);
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            bool flag = Program.ExecuteNextCommand();
            if (!flag)
            {
                break;
            }
        }
        Console.WriteLine(Program.output);
    }
}