import { Component, OnInit, ViewChild, Input} from '@angular/core';
import {
  RetentionsClient, RetentionUnitsClient, RetentionWaiversClient, RetentionCollectionUnitPlansClient,  RetentionApprovalsClient, 
  CreateRetentionCommand, CreateRetentionUnitCommand, CreateRetentionWaiverCommand, CreateRetentionCollectionUnitPlanCommand, CreateRetentionApprovalCommand,
  RetentionUnitsListViewModel, RetentionCollectionUnitPlansListViewModel, GetAllRetentionApprovalsQuery,
  UpdateRetentionUnitCommand, UpdateRetentionCollectionUnitPlanCommand, UpdateRetentionApprovalCommand, ApprovalType, RetentionApprovalsListViewModel,
  GetAllRetentionCollectionUnitPlansQuery, GetAllRetentionUnitsQuery, UnitType
} from '../ar.api';
import { SmartTableDatepickerRenderComponent, SmartTableDatepickerComponent } from '../smart-table-datepicker/smart-table-datepicker.component';
//import { SmartTableDatepickerRenderComponent, SmartTableDatepickerComponent } from '../smart-table-datepicker/smart-table-datepicker.component';
import { ServerDataSource, LocalDataSource } from 'ng2-smart-table';
@Component({
  selector: 'app-residential-customer-retention',
  templateUrl: './residential-customer-retention.component.html',
  styleUrls: ['./residential-customer-retention.component.css']
})


export class ResidentialCustomerRetentionComponent implements OnInit{
  vmRetention: CreateRetentionCommand;
  vmRetentionUnit: CreateRetentionUnitCommand;
  vmRetentionWaiver: CreateRetentionWaiverCommand;
  vmRetentionCollection: CreateRetentionCollectionUnitPlanCommand;
  vmRetentionApproval: CreateRetentionApprovalCommand;
  vmRetentionUnitList: RetentionUnitsListViewModel;
  vmRetentionUnitUpdate: UpdateRetentionUnitCommand;
  vmRetentionCollectionList: RetentionCollectionUnitPlansListViewModel;
  vmRetentionCollectionUpdate: UpdateRetentionCollectionUnitPlanCommand;
  vmRetentionApprovalUpdate: UpdateRetentionApprovalCommand;
  vmRetentionUnitQuery: GetAllRetentionUnitsQuery;
  vmRetentionCollectionQuery: GetAllRetentionCollectionUnitPlansQuery;
  vmRetentionApprovalQuery: GetAllRetentionApprovalsQuery;
  vmRetentionApprovalAddQuery: GetAllRetentionApprovalsQuery;
  vmRetentionApprovalList: RetentionApprovalsListViewModel;
  vmRetentionApprovalAddList: RetentionApprovalsListViewModel;
  @ViewChild('smartTableRetentionUnit') smartTableRetentionUnit;
  @ViewChild('smartTableCollection') smartTableCollection;
  @ViewChild('smartTableApproval') smartTableApproval;
  @ViewChild('smartTableApprovalAdd') smartTableApprovalAdd;

  @Input() placeholder: string = 'Choose a Date';
  retentionDate: Date;
  //retentionId: string;
  public radioData: any;
  public interests = []; cbMerge; cbExpedite; cbDiscounts; cbExceptional; cbUpgrade; cbDowngrade; cbSwapping; cbReschedule; cbWaive; cbVAS;
  is_edit: boolean = true;

  
  constructor(private clientRetention: RetentionsClient,
    private clientRetentionUnit: RetentionUnitsClient,
    private clientRetentionWaiver: RetentionWaiversClient,
    private clientRetentionCollection: RetentionCollectionUnitPlansClient,
    private clientRetentionApproval: RetentionApprovalsClient
  ) { }

  ngOnInit(): void {
    this.retentionDate = new Date();
    this.loadRetentionUnit();
    this.loadRetentionCollection();
    this.loadRetentionApproval();
    this.loadRetentionApprovalAdd();

  }
  onPercentChange(event) {
    let newValue = event.target.value + '%';
    if (event.target.value != Number) {
      console.debug('text');
      event.target.value = '';
    }
    event.target.value = newValue;
    //return newValue;
  }

  setTwoNumberDecimal($event) {
    $event.target.value = parseFloat($event.target.value).toFixed(2);
  }
  onCheckboxChagen(event, value) {
    //window.alert(event.target.checked);
    if (event.target.checked) { //(this.cbMerge) {

      this.interests.push(value);
    }
    if (!event.target.checked) { //(!this.cbMerge) {

      let index = this.interests.indexOf(value);

      if (index > -1) {

        this.interests.splice(index, 1);
      }
    }
    if (this.cbDiscounts || this.cbWaive || this.cbVAS) {
      this.is_edit = false;
    }
    else {
      this.is_edit = true;
    }
    //if(this.cbDiscounts)
    //console.log(event);
    //console.log("Interests array => " + JSON.stringify(this.interests, null, 2));
    console.log(this.interests.toString());
  }

  create(form) {
    console.debug("Create Retention");
    
    this.saveRetention(form);
    //window.alert("return parent -" + retentionId);
    //this.saveRetentionUnit(form, retentionId);
    //this.saveRetentionMerger(form, retentionId);
    //this.saveRetentionWaiver(form, retentionId);
    //this.saveRetentionCollection(form, retentionId);
    //this.saveRetentionNewPayment(form, retentionId);
    //this.saveRetentionApproval(form, retentionId);
    //this.saveRetentionAdditional(form);
  }

  async saveRetention(form) {
    this.vmRetention = new CreateRetentionCommand()
    //Requestor form
    this.vmRetention.clientName = form.value.clientName;
    this.vmRetention.customerID = form.value.customerID;
    this.vmRetention.contactNumber = form.value.contractNumber;
    this.vmRetention.currentProject = form.value.currentProject;
    this.vmRetention.currentUnitNumber = form.value.currentUnitNumber;
    this.vmRetention.price = form.value.price;
    this.vmRetention.gp = form.value.gp;
    this.vmRetention.gpValue = form.value.gpValue;
    this.vmRetention.simah = this.radioData;
    this.vmRetention.refNo = form.value.refNo;
    //Counter Offer Form
    this.vmRetention.typeOfCounterOffers = this.interests.toString();
    this.vmRetention.description = form.value.description;

    //let data = await this.clientRetention.create(this.vmRetention).toPromise().then(;
    //window.alert("parent " + data);
    //return data;
    //let data = "test";
    await this.clientRetention.create(this.vmRetention).toPromise().then(response => {
      //this.saveRetentionUnit(form, response);
      this.saveRetentionMerger(form, response);
      this.saveRetentionWaiver(form, response);
      //this.saveRetentionCollection(form, response);
      this.saveRetentionNewPayment(form, response);
      //this.saveRetentionApproval(form, response);
    });
  }
  saveRetentionUnit(form, retentionId) {
    this.vmRetentionUnit = new CreateRetentionUnitCommand();
    //Merger Current Form
    this.vmRetentionUnit.project = form.value.currentUnitProject;
    this.vmRetentionUnit.unitNo = form.value.currentUnitNo;
    this.vmRetentionUnit.price = form.value.currentUnitPrice;
    this.vmRetentionUnit.gp = form.value.currentUnitGP;
    this.vmRetentionUnit.gpValue = form.value.currentUnitGPValue;
    this.vmRetentionUnit.retentionId = retentionId;
    this.clientRetentionUnit.create(this.vmRetentionUnit).subscribe(response => {
      window.alert("current " + response);
    });
  }
  saveRetentionMerger(form, retentionId) {
    this.vmRetentionUnit = new CreateRetentionUnitCommand();
    //Merger Form
    this.vmRetentionUnit.project = form.value.unitProject;
    this.vmRetentionUnit.unitNo = form.value.unitNo;
    this.vmRetentionUnit.price = form.value.unitPrice;
    this.vmRetentionUnit.gp = form.value.unitGP;
    this.vmRetentionUnit.gpValue = form.value.unitGPValue;
    this.vmRetentionUnit.unitType = 1;
    this.vmRetentionUnit.retentionId = retentionId;
    this.clientRetentionUnit.create(this.vmRetentionUnit).subscribe(response => {
      window.alert("merger " + response);
    });
  }
  saveRetentionWaiver(form, retentionId) {
    this.vmRetentionWaiver = new CreateRetentionWaiverCommand();
    //Waiver Form
    this.vmRetentionWaiver.installementAmount = form.value.waivedInstallmentsAmount;
    this.vmRetentionWaiver.serviceChargeAmount = form.value.waivedServiceChargeAmount;
    this.vmRetentionWaiver.bearingCost = form.value.waivedBearingCost;
    this.vmRetentionWaiver.retentionId = retentionId;
    this.clientRetentionWaiver.create(this.vmRetentionWaiver).subscribe(response => {
      window.alert(response);
    });
  }
  saveRetentionCollection(form, retentionId) {
    this.vmRetentionCollection = new CreateRetentionCollectionUnitPlanCommand();
    //Collection Form
    this.vmRetentionCollection.soldDate = form.value.soldDate;
    this.vmRetentionCollection.paymentPlan = form.value.paymentPlan;
    this.vmRetentionCollection.firstInstallment = form.value.firstInstallment;
    this.vmRetentionCollection.lastInstallment = form.value.lastInstallment;
    this.vmRetentionCollection.noSettledInstallments = form.value.noSettledInstallment;
    this.vmRetentionCollection.collectedAmount = form.value.collectedAmount;
    this.vmRetentionCollection.collectedPercent = form.value.collectedPercent;
    this.vmRetentionCollection.dueAmount = form.value.dueAmount;
    this.vmRetentionCollection.remainingAmount = form.value.remainingAmount;
    this.vmRetentionCollection.retentionId = retentionId;
    this.clientRetentionCollection.create(this.vmRetentionCollection).subscribe(response => {
      window.alert("Collection " + response);
    });
  }
  saveRetentionNewPayment(form, retentionId) {
    this.vmRetentionCollection = new CreateRetentionCollectionUnitPlanCommand();
    //New Payment Form
    this.vmRetentionCollection.soldDate = form.value.newSoldDate;
    this.vmRetentionCollection.paymentPlan = form.value.newPaymentPlan;
    this.vmRetentionCollection.firstInstallment = form.value.newFirstInstallment;
    this.vmRetentionCollection.lastInstallment = form.value.newLastInstallment;
    this.vmRetentionCollection.noOfInstallments = form.value.newNoInstallment;
    this.vmRetentionCollection.collectedAmount = form.value.newCollectedAmount;
    this.vmRetentionCollection.totalCollectedAmount = form.value.newTotalCollectedAmount;
    this.vmRetentionCollection.collectedPercent = form.value.newCollectedPercent;
    this.vmRetentionCollection.dueAmount = form.value.newDueAmount;
    this.vmRetentionCollection.remainingAmount = form.value.newRemainingAmount;
    this.vmRetentionCollection.unitType = 1;
    this.vmRetentionCollection.retentionId = retentionId;
    this.clientRetentionCollection.create(this.vmRetentionCollection).subscribe(response => {
      window.alert("New Payment " + response);
    });
  }
  saveRetentionApproval(form, retentionId) {
    this.vmRetentionApproval = new CreateRetentionApprovalCommand();
    //Approval Committee Form
    this.vmRetentionApproval.name = form.value.name;
    this.vmRetentionApproval.position = form.value.position;
    this.vmRetentionApproval.signiture = form.value.signiture;
    this.vmRetentionApproval.retentionId = retentionId;
    this.clientRetentionApproval.create(this.vmRetentionApproval).subscribe(response => {
      window.alert("Committee " + response);
    });
  }
  //saveRetentionAdditional(form) {
  //  this.vmRetentionApproval = new CreateRetentionApprovalCommand();
  //  //Approval Additional Form
  //  this.vmRetentionApproval.name = form.value.name;
  //  this.vmRetentionApproval.position = form.value.position;
  //  this.vmRetentionApproval.signiture = form.value.signiture;
  //  this.vmRetentionApproval.approvalType = 1;
  //  this.vmRetentionApproval.retentionId = retentionId;
  //  this.clientRetentionApproval.create(this.vmRetentionApproval).subscribe(response => {
  //    window.alert("Additional " + response);
  //  });
  //}
  isDisabled(): boolean {
    return this.is_edit;
  }

  //Retention Unit smart table
  loadRetentionUnit() {
    this.vmRetentionUnitQuery = new GetAllRetentionUnitsQuery();
    this.vmRetentionUnitList = new RetentionUnitsListViewModel();
    this.vmRetentionUnitQuery.unitType = UnitType.Current;
    this.clientRetentionUnit.getAll(this.vmRetentionUnitQuery).subscribe(result => {
      this.vmRetentionUnitList = result;
    })
  }
  settingsRetentionUnit = {
    hideSubHeader: true,
    delete: {
      confirmDelete: true,

      deleteButtonContent: ' Delete ',
      saveButtonContent: 'save',
      cancelButtonContent: 'cancel'
    },
    add: {
      confirmCreate: true,
      saveButtonContent: ' save ',
      cancelButtonContent: ' Cancel '
    },
    edit: {
      confirmSave: true,
      saveButtonContent: ' Update ',
      cancelButtonContent: ' Cancel '
    },
    actions: {
      position: 'right',
    },
    columns: {
      project: {
        title: 'Project'
      },
      unitNo: {
        title: 'Unit No.'
      },
      price: {
        title: 'Price'
      },
      gp: {
        title: 'GP'
      },
      gpValue: {
        title: 'GP Value'
      }
    },
    attr: {
      class: 'table table-bordered'
    }
  }
  onDeleteConfirmRetentionUnit(event) {
    console.debug("Delete Event In Console")
    console.debug(event.data.id);

    if (window.confirm('Are you sure you want to delete?')) {
      this.clientRetentionUnit.delete(event.data.id).subscribe(result => {
        console.debug(result);
      }, error => console.error(error));
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirmRetentionUnit(event) {
    console.debug("Create Event In Console")
    console.debug(event);
    this.vmRetentionUnit = new CreateRetentionUnitCommand();
    //Merger Current Form
    this.vmRetentionUnit.project = event.newData.project;
    this.vmRetentionUnit.unitNo = event.newData.unitNo;
    this.vmRetentionUnit.price = event.newData.price;
    this.vmRetentionUnit.gp = event.newData.gp;
    this.vmRetentionUnit.gpValue = event.newData.gpValue;
    this.clientRetentionUnit.create(this.vmRetentionUnit).subscribe(response => {
      window.alert("current " + response);
      this.loadRetentionUnit();
      this.smartTableRetentionUnit.grid.createFormShown = false;
    });
    
  }

  onSaveConfirmRetentionUnit(event) {
    console.debug("Edit Event In Console")
    console.debug(event);

    this.vmRetentionUnitUpdate = new UpdateRetentionUnitCommand();
    //Merger Current Form
    this.vmRetentionUnitUpdate.id = event.newData.id
    this.vmRetentionUnitUpdate.project = event.newData.project;
    this.vmRetentionUnitUpdate.unitNo = event.newData.unitNo;
    this.vmRetentionUnitUpdate.price = event.newData.price;
    this.vmRetentionUnitUpdate.gp = event.newData.gp;
    this.vmRetentionUnitUpdate.gpValue = event.newData.gpValue;
    this.clientRetentionUnit.update(event.newData.id, this.vmRetentionUnitUpdate).subscribe(response => {
      window.alert("Edit " + response);
      this.loadRetentionUnit();
    });
    
  }

  addRecordRetentionUnit() {
    this.smartTableRetentionUnit.grid.createFormShown = true;
    this.smartTableRetentionUnit.grid.getNewRow();
  }


  //Collection Smart table
  loadRetentionCollection() {
    this.vmRetentionCollectionQuery = new GetAllRetentionCollectionUnitPlansQuery();
    this.vmRetentionCollectionList = new RetentionCollectionUnitPlansListViewModel();
    this.vmRetentionCollectionQuery.unitType = UnitType.Current;
    this.clientRetentionCollection.getAll(this.vmRetentionCollectionQuery).subscribe(result => {
      this.vmRetentionCollectionList = result;
    })
  }
  settingsCollection = {
    hideSubHeader: true,
    delete: {
      confirmDelete: true,

      deleteButtonContent: ' Delete ',
      saveButtonContent: 'save',
      cancelButtonContent: 'cancel'
    },
    add: {
      confirmCreate: true,
      saveButtonContent: ' save ',
      cancelButtonContent: ' Cancel '
    },
    edit: {
      confirmSave: true,
      saveButtonContent: ' Update ',
      cancelButtonContent: ' Cancel '
    },
    actions: {
      position: 'right',
    },
    columns: {
      soldDate: {
        title: 'Sold Date',
        type: 'custom',
        renderComponent: SmartTableDatepickerRenderComponent,
        width: '250px',
        filter: false,
        sortDirection: 'desc',
        editor: {
          type: 'custom',
          component: SmartTableDatepickerComponent,
        }
      },
      paymentPlan: {
        title: 'Payment Plan'
      },
      firstInstallment: {
        title: 'First Installment',
        type: 'custom',
        renderComponent: SmartTableDatepickerRenderComponent,
        width: '250px',
        filter: false,
        sortDirection: 'desc',
        editor: {
          type: 'custom',
          component: SmartTableDatepickerComponent,
        }
      },
      lastInstallment: {
        title: 'Last Installment',
        type: 'custom',
        renderComponent: SmartTableDatepickerRenderComponent,
        width: '250px',
        filter: false,
        sortDirection: 'desc',
        editor: {
          type: 'custom',
          component: SmartTableDatepickerComponent,
        }
      },
      noSettledInstallments: {
        title: 'No. Settled Installments'
      },
      collectedAmount: {
        title: 'Collected Amount'
      },
      collectedPercent: {
        title: 'Collected Percent'
      },
      dueAmount: {
        title: 'Due Amount'
      },
      remainingAmount: {
        title: 'Remaining Amount'
      }
    },
    attr: {
      class: 'table table-bordered'
    }
  }
  onDeleteConfirmCollection(event) {
    console.debug("Delete Event In Console")
    console.debug(event.data.id);

    if (window.confirm('Are you sure you want to delete?')) {
      this.clientRetentionCollection.delete(event.data.id).subscribe(result => {
        console.debug(result);
      }, error => console.error(error));
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirmCollection(event) {
    console.debug("Create Event In Console")
    console.debug(event);
    this.vmRetentionCollection = new CreateRetentionCollectionUnitPlanCommand();
    this.vmRetentionCollection.soldDate = event.newData.soldDate;
    this.vmRetentionCollection.paymentPlan = event.newData.paymentPlan;
    this.vmRetentionCollection.firstInstallment = event.newData.firstInstallment;
    this.vmRetentionCollection.lastInstallment = event.newData.lastInstallment;
    this.vmRetentionCollection.noSettledInstallments = event.newData.noSettledInstallments;
    this.vmRetentionCollection.collectedAmount = event.newData.collectedAmount;
    this.vmRetentionCollection.collectedPercent = event.newData.collectedPercent;
    this.vmRetentionCollection.dueAmount = event.newData.dueAmount;
    this.vmRetentionCollection.remainingAmount = event.newData.remainingAmount;

    this.clientRetentionCollection.create(this.vmRetentionCollection).subscribe(response => {
      window.alert("current " + response);
      this.loadRetentionCollection();
      this.smartTableCollection.grid.createFormShown = false;
    });

  }

  onSaveConfirmCollection(event) {
    console.debug("Edit Event In Console")
    console.debug(event);

    this.vmRetentionCollectionUpdate = new UpdateRetentionCollectionUnitPlanCommand();
    this.vmRetentionCollectionUpdate.id = event.newData.id;
    this.vmRetentionCollectionUpdate.soldDate = event.newData.soldDate;
    this.vmRetentionCollectionUpdate.paymentPlan = event.newData.paymentPlan;
    this.vmRetentionCollectionUpdate.firstInstallment = event.newData.firstInstallment;
    this.vmRetentionCollectionUpdate.lastInstallment = event.newData.lastInstallment;
    this.vmRetentionCollectionUpdate.noSettledInstallments = event.newData.noSettledInstallments;
    this.vmRetentionCollectionUpdate.collectedAmount = event.newData.collectedAmount;
    this.vmRetentionCollectionUpdate.collectedPercent = event.newData.collectedPercent;
    this.vmRetentionCollectionUpdate.dueAmount = event.newData.dueAmount;
    this.vmRetentionCollectionUpdate.remainingAmount = event.newData.remainingAmount;
    this.clientRetentionCollection.update(event.newData.id, this.vmRetentionCollectionUpdate).subscribe(response => {
      window.alert("Edit " + response);
      this.loadRetentionCollection();
    });

  }

  addRecordCollection() {
    this.smartTableCollection.grid.createFormShown = true;
    this.smartTableCollection.grid.getNewRow();
  }


  //Approval committee smart table
  loadRetentionApproval() {
    this.vmRetentionApprovalQuery = new GetAllRetentionApprovalsQuery();
    this.vmRetentionApprovalQuery.approvalType = ApprovalType.Committee;
    this.clientRetentionApproval.getAll(this.vmRetentionApprovalQuery).subscribe(result => {
      this.vmRetentionApprovalList = result;
      //console.debug(result);
      //this.source = new LocalDataSource(result.retentionApprovals);
    })
  }
  //title = 'app';
  //data: any = [];
  ///source: LocalDataSource;
  settingsApproval = {

    hideSubHeader: true,
    delete: {
      confirmDelete: true,

      deleteButtonContent: ' Delete ',
      saveButtonContent: 'save',
      cancelButtonContent: 'cancel'
    },
    add: {
      confirmCreate: true,
      saveButtonContent: ' save ',
      cancelButtonContent: ' Cancel '
    },
    edit: {
      confirmSave: true,
      saveButtonContent: ' Update ',
      cancelButtonContent: ' Cancel '
    },
    actions: {
      position: 'right',
    },
    columns: {
      name: {
        title: 'Name'
      },
      position: {
        title: 'Position'
      },
      signiture: {
        title: 'Signature'
      }
    },
    attr: {
      class: 'table table-bordered'
    },
    pager: {
      perPage: 3
    },
  }
  
  onDeleteConfirmApproval(event) {
    console.debug("Delete Event In Console")
    console.debug(event.data.id);

    if (window.confirm('Are you sure you want to delete?')) {
      this.clientRetentionApproval.delete(event.data.id).subscribe(result => {
        console.debug(result);
      }, error => console.error(error));
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirmApproval(event) {
    console.debug("Create Event In Console")
    console.debug(event);
    this.vmRetentionApproval = new CreateRetentionApprovalCommand();
    //Merger Current Form
    this.vmRetentionApproval.name = event.newData.name;
    this.vmRetentionApproval.position = event.newData.position;
    this.vmRetentionApproval.signiture = event.newData.signiture;
    this.vmRetentionApproval.approvalType = ApprovalType.Committee;
    this.clientRetentionApproval.create(this.vmRetentionApproval).subscribe(response => {
      window.alert("current " + response);
      this.loadRetentionApproval();
      this.smartTableApproval.grid.createFormShown = false;
    });

  }

  onSaveConfirmApproval(event) {
    console.debug("Edit Event In Console")
    console.debug(event);

    this.vmRetentionApprovalUpdate = new UpdateRetentionApprovalCommand();
    //Merger Current Form
    this.vmRetentionApprovalUpdate.id = event.newData.id
    this.vmRetentionApprovalUpdate.name = event.newData.name;
    this.vmRetentionApprovalUpdate.position = event.newData.position;
    this.vmRetentionApprovalUpdate.signiture = event.newData.signiture;
    this.vmRetentionApproval.approvalType = ApprovalType.Committee;
    this.clientRetentionApproval.update(event.newData.id, this.vmRetentionApprovalUpdate).subscribe(response => {
      window.alert("Edit " + response);
      this.loadRetentionApproval();
    });

  }

  addRecordApproval() {
    this.smartTableApproval.grid.createFormShown = true;
    this.smartTableApproval.grid.getNewRow();
  }


  //Approval Additional smart table
  loadRetentionApprovalAdd() {
    this.vmRetentionApprovalAddQuery = new GetAllRetentionApprovalsQuery();
    this.vmRetentionApprovalAddQuery.approvalType = ApprovalType.Additional;
    this.clientRetentionApproval.getAll(this.vmRetentionApprovalAddQuery).subscribe(result => {
      this.vmRetentionApprovalAddList = result;
      //this.source = result.data;
    })
  }
  settingsApprovalAdd = {
    hideSubHeader: true,
    delete: {
      confirmDelete: true,

      deleteButtonContent: ' Delete ',
      saveButtonContent: 'save',
      cancelButtonContent: 'cancel'
    },
    add: {
      confirmCreate: true,
      saveButtonContent: ' save ',
      cancelButtonContent: ' Cancel '
    },
    edit: {
      confirmSave: true,
      saveButtonContent: ' Update ',
      cancelButtonContent: ' Cancel '
    },
    actions: {
      position: 'right',
    },
    columns: {
      name: {
        title: 'Name'
      },
      position: {
        title: 'Position'
      },
      signiture: {
        title: 'Signature'
      }
    },
    attr: {
      class: 'table table-bordered'
    }
  }
  onDeleteConfirmApprovalAdd(event) {
    console.debug("Delete Event In Console")
    console.debug(event.data.id);

    if (window.confirm('Are you sure you want to delete?')) {
      this.clientRetentionApproval.delete(event.data.id).subscribe(result => {
        console.debug(result);
      }, error => console.error(error));
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirmApprovalAdd(event) {
    console.debug("Create Event In Console")
    console.debug(event);
    this.vmRetentionApproval = new CreateRetentionApprovalCommand();
    //Merger Current Form
    this.vmRetentionApproval.name = event.newData.name;
    this.vmRetentionApproval.position = event.newData.position;
    this.vmRetentionApproval.signiture = event.newData.signiture;
    this.vmRetentionApproval.approvalType = ApprovalType.Additional;
    this.clientRetentionApproval.create(this.vmRetentionApproval).subscribe(response => {
      window.alert("current " + response);
      this.loadRetentionApprovalAdd();
      this.smartTableApprovalAdd.grid.createFormShown = false;
    });

  }

  onSaveConfirmApprovalAdd(event) {
    console.debug("Edit Event In Console")
    console.debug(event);

    this.vmRetentionApprovalUpdate = new UpdateRetentionApprovalCommand();
    //Merger Current Form
    this.vmRetentionApprovalUpdate.id = event.newData.id
    this.vmRetentionApprovalUpdate.name = event.newData.name;
    this.vmRetentionApprovalUpdate.position = event.newData.position;
    this.vmRetentionApprovalUpdate.signiture = event.newData.signiture;
    this.vmRetentionApprovalUpdate.approvalType = ApprovalType.Additional;
    this.clientRetentionApproval.update(event.newData.id, this.vmRetentionApprovalUpdate).subscribe(response => {
      window.alert("Edit " + response);
      this.loadRetentionApprovalAdd();
    });

  }

  addRecordApprovalAdd() {
    this.smartTableApprovalAdd.grid.createFormShown = true;
    this.smartTableApprovalAdd.grid.getNewRow();
  }
}
