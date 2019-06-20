import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { RetentionsClient, RetentionsListViewModel, RetentionDto } from '../ar.api';
import { RetentionDeleteComponent } from '../retention-delete/retention-delete.component';
declare var $;
@Component({
  selector: 'app-retention',
  templateUrl: './retention.component.html',
  styleUrls: ['./retention.component.css']
})
export class RetentionComponent implements OnDestroy, OnInit {
  private client: RetentionsClient
  retentionVm: RetentionDto[];
  vm: RetentionsListViewModel = new RetentionsListViewModel();
  vmDelete: RetentionDeleteComponent = new RetentionDeleteComponent();
  @ViewChild('dataTable') table : ElementRef;
  dataTable: any;
  dtOptions: any = {};
  //dtTrigger: Subject = new Subject();
  //datas: data[] = [];
  constructor(client: RetentionsClient) {
    this.client = client;
  }

  ngOnInit(): void {
    // this.client.getAll().subscribe(result => {
    //   this.retentionVm = result.retentions;
    // }, error => console.error(error));

    // this.dtOptions = {
    //   "searchable": true
    // };
    // this.dataTable = $(this.table.nativeElement);
    // $(()=>{  
    //   $('table.display').DataTable(this.dtOptions);
    //   });

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true,

      ajax: (dataTablesParameters: any, callback) => {
        this.client.getAll().subscribe(result => {
          this.retentionVm = result.retentions;
          //result.retentions.
          console.debug(result.retentions);
          callback({
            recordsTotal: result.retentions.length,
            recordsFiltered: result.retentions.length,
            data: result.retentions
          });
        }, error => console.error(error));
        
      },
      columns: [
        { data: 'clientName' },
        { data: 'customerID' },
        { data: 'contactNumber' },
        { data: 'currentProject' },
        { data: 'currentUnitNumber' },
        { data: 'price' },
        { data: 'gp' },
        { data: 'gpValue' },
        { data: 'simah' },
        { data: 'description' },
        { data: 'typeOfCounterOffers' }
      ],
      language: {
        emptyTable: "No data available in table"
      },
      responsive: true
    };
     this.dataTable = $(this.table.nativeElement);
     this.dataTable.DataTable(this.dtOptions);

  }

  ngOnDestroy(): void {
    //this.dtTrigger.unsubscribe();
  }

}
