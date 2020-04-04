import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {LoginComponent} from '../../../../../../authentication/login/login.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidebarToggle = new EventEmitter();

  constructor(public dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  sidebarToggleHandler() {
    this.sidebarToggle.emit();
  }

  loginHandler() {
    const loginDialog = this.dialog.open(LoginComponent, {
      width: '300px',
      data: 10,
      hasBackdrop: true,
      panelClass: 'alimzfr-dialog-panel'
    });


    loginDialog.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });

  }

}
