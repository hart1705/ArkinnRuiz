import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RetentionsClient, RetentionApprovalsClient, RetentionWaiversClient, RetentionCollectionUnitPlansClient, RetentionUnitsClient } from './ar.api';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RetentionComponent } from './retention/retention.component';
import { RetentionAddComponent } from './retention-add/retention-add.component';
import { RetentionEditComponent } from './retention-edit/retention-edit.component';
import { RetentionDeleteComponent } from './retention-delete/retention-delete.component';
import { TabsComponent } from './tabs/tabs.component';
import { ResidentialCustomerRetentionComponent } from './residential-customer-retention/residential-customer-retention.component';
import { AutofocusDirective } from './autofocus.directive';
import { DataTablesModule } from 'angular-datatables';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
//import { AngularSignaturePadModule } from 'angular-signature-pad';
import { SmartTableDatepickerRenderComponent, SmartTableDatepickerComponent } from './smart-table-datepicker/smart-table-datepicker.component';
import { ZipValidatorDirective } from './zip-validator.directive';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RetentionComponent,
    RetentionAddComponent,
    RetentionEditComponent,
    RetentionDeleteComponent,
    TabsComponent,
    ResidentialCustomerRetentionComponent,
    AutofocusDirective,
    SmartTableDatepickerComponent,
    SmartTableDatepickerRenderComponent,
    ZipValidatorDirective
  ],
  entryComponents: [
    SmartTableDatepickerComponent,
    SmartTableDatepickerRenderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    DataTablesModule,
    Ng2SmartTableModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    //AngularSignaturePadModule.forRoot(),
    ReactiveFormsModule, NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'retention', component: RetentionComponent },
      { path: 'retention-add', component: RetentionAddComponent },
      { path: 'residential-customer-retention', component: ResidentialCustomerRetentionComponent },
    ])
  ],
  providers: [RetentionsClient, RetentionApprovalsClient, RetentionWaiversClient, RetentionCollectionUnitPlansClient, RetentionUnitsClient ],
  bootstrap: [AppComponent]
})
export class AppModule { }
