import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {UserCommentModel} from './contact.models/contact.model';
import {ContactService} from './contact.services/contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  contactForm = new FormGroup({
    name: new FormControl(),
    email: new FormControl(),
    comment: new FormControl()
  });

  constructor(private service: ContactService) {
  }

  ngOnInit(): void {
  }

  onContactFormSubmit() {
    if (this.contactForm.valid) {
      this.service.sendComment(this.contactForm.value).subscribe(value => {
        console.log(value);
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
}
