import { Component } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
})
export class CreateTaskComponent {
  task: any = {
    title: '',
    description: '',
    dueDate: '',
    status: 'Pending',
  };

  constructor(private taskService: TaskService, private router: Router) {}

  create() {
    console.log(this.task); // check payload

    this.taskService.createTask(this.task).subscribe({
      next: () => {
        alert('Task Created Successfully');
        this.router.navigate(['/tasks']);
      },

      error: (err) => {
        console.log(err);
        alert('Task creation failed');
      },
    });
  }
}
