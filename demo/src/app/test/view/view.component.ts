import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/service/student.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor(private service: StudentService, private toastr: ToastrService) { }
data:any
  ngOnInit(): void {
    this.service.getAll().subscribe((list:any) => {
      this.data = list;
    })
  }

  delete(id:any){
    this.service.delete(id).subscribe(res => {
      this.toastr.success('Record Deleted ');
      this.ngOnInit();
    })
  }
}
