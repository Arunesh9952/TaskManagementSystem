import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html'
})
export class TasksComponent implements OnInit {

  tasks:any[] = [];

  constructor(private taskService:TaskService){}

  ngOnInit(){
    this.loadTasks();
  }

  loadTasks(){

    this.taskService.getTasks().subscribe((res:any)=>{

      console.log("Tasks:",res);

      this.tasks = res;

    });

  }

  delete(id:number){

    console.log("Deleting ID:",id);

    this.taskService.deleteTask(id).subscribe(()=>{

      this.loadTasks();

    });

  }

}