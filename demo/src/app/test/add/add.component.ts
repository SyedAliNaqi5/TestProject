import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../service/student.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor(private service: StudentService,
   private route: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  form = new FormGroup({

    firstName: new FormControl(''),
    lastName: new FormControl(''),
    fatherName: new FormControl(''),
    city: new FormControl(''),
    dateOfBirth: new FormControl(''),
    startDate: new FormControl(''),

  });
  Add() {
    this.service.add(this.form.value).subscribe((result) => {
      this.toastr.success('Record Added ');
      this.route.navigate(['/']);
    });
  }
}
