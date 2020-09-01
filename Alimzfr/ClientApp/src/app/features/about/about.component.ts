import {Component, OnDestroy, OnInit} from '@angular/core';
import {AboutService} from './about.services/about.service';
import {AboutModel} from './about.models/about.model';
import {
  MonacoEditorComponent,
  MonacoEditorConstructionOptions,
  MonacoEditorLoaderService,
  MonacoStandaloneCodeEditor
} from '@materia-ui/ngx-monaco-editor';
import {take} from 'rxjs/internal/operators';
import {filter} from 'rxjs/internal/operators/filter';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Subscription} from 'rxjs';
import {AuthService} from '../../authentication/auth.service';
import {ConnectionService} from '../../shareServices/connection.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit, OnDestroy {
  abouts: AboutModel[];
  loading: boolean;
  monacoComponent: MonacoEditorComponent;
  editorOptions: MonacoEditorConstructionOptions;
  isAuthenticated = false;
  private userSub: Subscription;
  isOnline: boolean;

  constructor(private service: AboutService,
              private monacoLoaderService: MonacoEditorLoaderService,
              private message: MatSnackBar,
              private authService: AuthService,
              private connection: ConnectionService) {
    this.isOnline = true;
  }

  ngOnInit(): void {
    this.loading = true;
    this.userSub = this.authService.user.subscribe(user => {
      this.isAuthenticated = !!user;
    });

    this.getAbouts();
    this.editorOptions = {
      theme: 'myCustomTheme',
      language: 'html',
      roundedSelection: true,
      autoIndent: true,
      minimap: {
        enabled: false
      }
    };
    this.monacoLoaderService.isMonacoLoaded$
      .pipe(filter(isLoaded => isLoaded), take(1))
      .subscribe(() => {
        monaco.editor.defineTheme('myCustomTheme', {
          base: 'vs-dark', // can also be vs or hc-black
          inherit: true, // can also be false to completely replace the builtin rules
          rules: [
            {token: 'comment', foreground: 'ffa500', fontStyle: 'italic underline'},
            {token: 'comment.js', foreground: '008800', fontStyle: 'bold'},
            {token: 'comment.css', foreground: '0000ff'} // will inherit fontStyle from `comment` above
          ],
          colors: {}
        });
        this.loading = false;
      });
    this.connection.isOnline().subscribe(() => {
      this.isOnline = true;
    }, error => {
      this.isOnline = false;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }

  getAbouts() {
    this.service.getAbouts().subscribe(value => {
      this.abouts = value;
    });
  }

  updateAbout(aboutId: number) {
    const about = this.abouts.find(x => x.id === aboutId);
    this.service.updateAbout(about).subscribe(value => {
      this.message.open('Update Success', '×', {
        duration: 5000,
        panelClass: ['alimzfr-message-success'],
        verticalPosition: 'top',
      });
    }, error => {
      if (error.status === 401) {
        this.message.open('Access Denied', '×', {
          duration: 5000,
          panelClass: 'alimzfr-message-error',
          verticalPosition: 'top',
        });
      } else {
        this.message.open('Error Occurred', '×', {
          duration: 5000,
          panelClass: 'alimzfr-message-error',
          verticalPosition: 'top',
        });
      }
    });
  }
}
