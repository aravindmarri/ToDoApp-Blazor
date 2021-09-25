using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Pages
{
    public partial class ToDo
    {
        private IList<TodoItem> todos = new List<TodoItem>();
        private string newTodo;
        private string newDescription;
        private int Id = 0;
        private int EditId;
        private bool NewTaskvisible;
        private bool Editvisible;
        private void AddTodo()
        {
            if (!string.IsNullOrEmpty(newTodo))
            {
                todos.Add(new TodoItem()
                {
                    Id = Id,
                    Title = newTodo,
                    Description = newDescription
                });
                Id++;
                NewTaskvisible = false;
                newTodo = "";
                newDescription = "";
            }
        }
        private void EditTodo()
        {
            Editvisible = false;
        }
        private void AddNewTask() => NewTaskvisible = true;
        private void EditTask(int TaskId) {
            EditId = TaskId;
            Editvisible = true; 
        }
        private void DeleteTask(int TaskId)
        {
            EditId = TaskId;
            var item = todos.SingleOrDefault(x => x.Id == TaskId);
            if (item != null)
                todos.Remove(item);
            //todos.Remove(TaskId);
        }
        void Cancel() => NewTaskvisible = false;
    }
}
