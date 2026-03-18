import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  api = 'http://localhost:5063/api/Task';

  constructor(private http: HttpClient) {}

  getTasks() {
    return this.http.get(this.api);
  }

  createTask(task: any) {
    return this.http.post(this.api, task);
  }

  deleteTask(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }
}
