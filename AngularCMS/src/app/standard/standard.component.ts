import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Standard } from 'Model/standard';
import { FormBuilder, Validators } from '@angular/forms';
import { StandardService } from 'Services/standard.service';

@Component({
  selector: 'app-standard',
  templateUrl: './standard.component.html',
  styleUrls: ['./standard.component.css']
})
export class StandardComponent implements OnInit {

  dataSaved = false;  
  standardForm: any;  
  allStandard: Observable<Standard[]>;  
  standardIdUpdate = null;  
  massage = null;  

  constructor(private formbulider: FormBuilder, private standardService:StandardService) { }  
  
  ngOnInit() {  
    this.standardForm = this.formbulider.group({  
      Name: ['', [Validators.required]],  
      IsDeleted: ['', [Validators.required]],  
    });  
    this.loadAllStandard();  
  }  

  loadAllStandard() {  
    this.allStandard = this.standardService.getAllStandards();  
  }  
}
