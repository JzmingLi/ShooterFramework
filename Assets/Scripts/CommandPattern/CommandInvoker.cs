using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class CommandBuffer
    {
        private static Stack<ICommand> _undoStack = new Stack<ICommand>();
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
        }
        public static void CancelCommand()
        {
            if (_undoStack.Count > 0)
            {
                ICommand activeCommand = _undoStack.Pop();
                activeCommand.Cancel();
            }
        }
    }
}
