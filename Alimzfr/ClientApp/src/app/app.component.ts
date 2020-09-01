import {Component, OnInit} from '@angular/core';
import {FaIconLibrary} from '@fortawesome/angular-fontawesome';
import {fas} from '@fortawesome/free-solid-svg-icons';
import {far} from '@fortawesome/free-regular-svg-icons';
import {fab} from '@fortawesome/free-brands-svg-icons';
import {AuthService} from './authentication/auth.service';
import {ConnectionService} from './shareServices/connection.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isConnect: boolean;

  constructor(private library: FaIconLibrary,
              private authService: AuthService,
              private connection: ConnectionService) {
    this.isConnect = true;
    library.addIconPacks(fas, far, fab);
  }

  ngOnInit() {
    this.authService.autoLogin();
    console.log(this.connection.isOnline());
  }

}
