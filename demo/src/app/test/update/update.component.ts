import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from 'src/app/service/student.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  constructor(private service: StudentService,private router :ActivatedRoute,
    private route: Router, private toastr: ToastrService) { }
  form = new FormGroup({

    firstName: new FormControl(''),
    lastName: new FormControl(''),
    fatherName: new FormControl(''),
    city: new FormControl(''),
    dateOfBirth: new FormControl(''),
    startDate: new FormControl(''),

  });
  ngOnInit(): void {
    this.service.getbyid(this.router.snapshot.params['id']).subscribe((result: any) => {
      this.form = new FormGroup({
        firstName: new FormControl(result['firstName']),
        lastName: new FormControl(result['lastName']),
        fatherName: new FormControl(result['fatherName']),
        city: new FormControl(result['city']),
        dateOfBirth: new FormControl(result['dateOfBirth']),
        startDate: new FormControl(result['startDate']),
        id: new FormControl(result['id']),
      });
    })
  }
  Update() {
    this.service.update(this.form.value).subscribe((result) => {
      this.toastr.success('Record updated ');
      this.route.navigate(['/']);
    });
  }

}
