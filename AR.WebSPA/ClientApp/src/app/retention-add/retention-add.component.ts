import { Component, OnInit } from '@angular/core';
import { RetentionsClient, CreateRetentionCommand } from '../ar.api';
@Component({
  selector: 'app-retention-add',
  templateUrl: './retention-add.component.html',
  styleUrls: ['./retention-add.component.css']
})
export class RetentionAddComponent implements OnInit {
  vm: CreateRetentionCommand;

  constructor(private client: RetentionsClient) {
    this.vm = new CreateRetentionCommand();
  }
  create(form) {
    //window.alert(form.value.title);
    this.vm.clientName = form.value.clientName;
    this.vm.customerID = form.value.customerID;
    this.vm.contactNumber = form.value.contractNumber;
    this.vm.currentProject = form.value.currentProject;
    this.vm.currentUnitNumber = form.value.currentUnitNumber;
    this.vm.price = form.value.price;
    this.vm.gp = form.value.gp;
    this.vm.gpValue = form.value.gpValue;
    this.vm.simah = form.value.simah;
    this.vm.typeOfCounterOffers = form.value.typeOfCounterOffers;
    this.vm.description = form.value.description;
    this.vm.vas = form.value.vas;
    this.vm.refNo = form.value.refNo;

    //var events = this.vm.toJSON(form);
    this.client.create(this.vm).subscribe(response => {
      window.alert(response);
    });
  }
  ngOnInit() {
  }

}
