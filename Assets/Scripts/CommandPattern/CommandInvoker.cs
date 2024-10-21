using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class CommandInvoker
    {
        private static readonly int MAX_COMMANDS = 10;
        private static List<ICommand> _undoList = new List<ICommand>();
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoList.Add(command);
            if (_undoList.Count > MAX_COMMANDS)
            {
                ICommand deletedCommand = _undoList[0];
                deletedCommand.ClearData();
                _undoList.RemoveAt(0);
            }
        }
        public static void UndoCommand()
        {
            if (_undoList.Count > 0)
            {
                ICommand activeCommand = _undoList[^1];
                _undoList.Remove(activeCommand);
                activeCommand.Undo();
            }
        }
    }
}
