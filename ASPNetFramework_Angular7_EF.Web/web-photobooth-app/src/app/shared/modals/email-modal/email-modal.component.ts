import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-email-modal',
  templateUrl: './email-modal.component.html',
  styleUrls: ['./email-modal.component.scss']
})
export class EmailModalComponent implements OnInit {

  @Input()
  message;

  @Input()
  yesLabel;

  @Input()
  noLabel;

  email: string;
  
  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  ok(){
    this.email = (<HTMLInputElement>document.getElementById("email")).value;
    console.log("okay >> ", this.email);
    this.activeModal.close(this.email);
  }

  close(){
    console.log("close");
    this.activeModal.dismiss('close');
  }
}
