import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup} from '@angular/forms';
import {AuthService} from '../auth.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isAuthenticated = false;
  private userSub: Subscription;

  loginForm = new FormGroup({
    username: new FormControl(),
    password: new FormControl()
  });
  loading: boolean;

  constructor(
    public dialogRef: MatDialogRef<LoginComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private service: AuthService) {
    this.loading = false;
  }

  ngOnInit(): void {
    this.userSub = this.service.user.subscribe(user => {
      this.isAuthenticated = !!user;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onLoginFormSubmit() {
    this.loading = true;
    this.service.login(this.loginForm.value).subscribe(value => {
      this.loading = false;
      this.dialogRef.close();
    }, error => {
      console.log(error);
      this.loading = false;
    });
  }
}
