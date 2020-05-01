import {Component, OnInit, Output, EventEmitter, OnDestroy} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {LoginComponent} from '../../../../../../authentication/login/login.component';
import {AuthService} from 'src/app/authentication/auth.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  isAuthenticated: boolean;
  displayName: string;
  private userSub: Subscription;
  @Output() sidebarToggle = new EventEmitter();

  constructor(public dialog: MatDialog,
              private service: AuthService) {
    this.isAuthenticated = false;
    this.displayName = null;
  }

  ngOnInit(): void {
    this.userSub = this.service.user.subscribe(user => {
      this.isAuthenticated = !!user;
      this.displayName = user?.displayName;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }

  sidebarToggleHandler() {
    this.sidebarToggle.emit();
  }

  loginHandler() {
    window.scrollTo({top: 0});
    const loginDialog = this.dialog.open(LoginComponent, {
      width: '300px',
      data: 10,
      hasBackdrop: true,
      panelClass: 'alimzfr-dialog-panel'
    });
  }

  logoutHandler() {
    this.service.logout().subscribe();
  }

}
