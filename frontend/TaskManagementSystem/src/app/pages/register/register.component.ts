import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  formData: any = {};

  constructor(private auth: AuthService, private router: Router) {}

  register() {
    this.auth.register(this.formData).subscribe((res) => {
      alert('Registration Success');

      this.router.navigate(['/login']);
    });
  }
}
