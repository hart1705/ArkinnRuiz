import { Component } from '@angular/core';
import { RetentionsClient, CreateRetentionCommand } from '../ar.api';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  //template: ` 
  //<h1>Retentions Tab</h1>
  //<ngx-tabs>
  //  <ngx-tab tabTitle="Retention List">
  //    sdfa
  //  </ngx-tab>
  //  <ngx-tab tabTitle="Retention Add">
  //    Retention Add
  //  </ngx-tab>
  //</ngx-tabs>
  //`
  styles: [
    `
    :host { color: gray; }

    :host ::ng-deep .tabset1 a.nav-link {
      color: green;
    }
    
    :host ::ng-deep .tabset1 a.nav-link.active {
      color: red;
      font-weight: bold;
    }
`
  ]
})
export class TabsComponent  {
  vm: CreateRetentionCommand = new CreateRetentionCommand();

  constructor(private client: RetentionsClient) { }
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

    this.client.create(this.vm).subscribe(response => {
      window.alert(response);
    });
  }
}
