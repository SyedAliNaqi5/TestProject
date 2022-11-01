import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { AddComponent } from './add/add.component';
import { ViewComponent } from './view/view.component';
import { UpdateComponent } from './update/update.component';
import{ReactiveFormsModule,FormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    AddComponent,
    ViewComponent,
    UpdateComponent
  ],
  imports: [
    CommonModule,
    TestRoutingModule,ReactiveFormsModule,FormsModule
  ]
})
export class TestModule { }
