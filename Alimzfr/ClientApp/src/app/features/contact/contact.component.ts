import {AfterViewChecked, AfterViewInit, Component, ElementRef, HostListener, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ContactService} from './contact.services/contact.service';
import {MatSnackBar} from '@angular/material/snack-bar';

declare var Particles: any;

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('communicateElement', {read: ElementRef}) communicateElement: ElementRef;
  @ViewChild('formElement', {read: ElementRef}) formElement: ElementRef;
  particles: any;
  contactForm = new FormGroup({
    name: new FormControl(),
    email: new FormControl(),
    subject: new FormControl(),
    comment: new FormControl()
  });
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.communicateElement.nativeElement.style.height = this.formElement.nativeElement.offsetHeight + 'px';
  }

  constructor(private service: ContactService,
              private message: MatSnackBar) {
  }

  ngOnInit(): void {
  }

  onContactFormSubmit() {
    if (this.contactForm.valid) {
      this.service.sendComment(this.contactForm.value).subscribe(value => {
        this.message.open('Thanks For Message', '×', {
          duration: 5000,
          panelClass: ['alimzfr-message-success'],
          verticalPosition: 'top',
        });
      }, error => {
        this.message.open('Error Occurred', '×', {
          duration: 5000,
          panelClass: 'alimzfr-message-error',
          verticalPosition: 'top',
        });
      });
      this.contactForm.reset();
    }
  }

  communicateNavigate(type: ('whatsapp' | 'linkedin' | 'github' | 'email'), url: string) {
    switch (type) {
      case 'email':
        window.open('mailto:' + url, '_blank');
        break;
      case 'github':
        window.open(url, '_blank');
        break;
      case 'linkedin':
        window.open(url, '_blank');
        break;
      case 'whatsapp':
        window.open('https://api.whatsapp.com/send?phone=' + url, '_blank');
        break;
      default:
        return;
    }

  }

  ngAfterViewInit(): void {
    this.communicateElement.nativeElement.style.height = this.formElement.nativeElement.offsetHeight + 'px';
    this.initParticles();
  }

  ngOnDestroy(): void {
    this.destroyParticles();
  }

  initParticles() {
    this.particles = Particles.init({
      selector: '.Particles-background',
      maxParticles: 40,
      color: '#6c757d',
      speed: 0.3,
      connectParticles: true,
    });
  }

  destroyParticles() {
    this.particles.destroy();
  }
}
