using System.Collections.Generic;
using Nancy;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule:NancyModule
  {
    public HomeModule()
    {
      Get["/"]=_=>View["add_new_task.cshtml"];
      Get["/task_added.cshtml"]=_=>{
        Task newTask = new Task(Request.Query["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
      };
      Get["/view_all_tasks"] =_=>{
        List<string> taskList = Task.GetAll();
        return View["view_all_tasks.cshtml", taskList];
      };
      Post["/task_added"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
    };
    }
  }
}
