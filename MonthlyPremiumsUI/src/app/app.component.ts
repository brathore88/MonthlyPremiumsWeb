import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CalculatePremium } from './Premium.model';
import { PremiumService } from './premium.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public birthdate: any;
  public age: number | undefined;
  public deathPremium: any;
  isSubmitted = false;
  submitted = false;

  Occupations = {'Cleaner':'Light Manual', 'Doctor':'Professional', 'Author':'White Collar', 'Farmer':'Heavy Manual'
  , 'Mechanic':'Heavy Manual', 'Florist':'Light Manual' }
  showAge: any ;
 
  constructor(public fb: FormBuilder,private httpPremiumService:PremiumService,private http: HttpClient) {}
  registrationForm = this.fb.group({
    OccupationType: ['', [Validators.required]],
    DeathPremium: ['0', [Validators.required]],
    SumInsured: ['', [Validators.required]],
    Age: ['', [Validators.required]],
    DateofBirth: ['', [Validators.required]],
    Name: ['', [Validators.required]],
  });
  
  get f(): { [key: string]: AbstractControl } {
    return this.registrationForm.controls;
  }
  changeOccupation(e: any) {
    this.submitted = true;
    console.log('this.registrationForm.invalid',this.registrationForm.invalid)
    if (this.registrationForm.invalid) {
      return;
    }
    const formData = new FormData();
    formData.append('Age', this.showAge);
    formData.append('SumInsured', this.registrationForm.get('SumInsured')?.value);
    formData.append('OccupatioRating', e.target.value);

    
    const calculatePremium:CalculatePremium = {
        Age: this.showAge,
        SumInsured: this.registrationForm.get('SumInsured')?.value,
        OccupatioRating: e.target.value
    }

    
    this.calculateAge();

    this.postPremium(e);
  }
   calculateAge() {
    
    if (this.age) {
      const convertAge = new Date(this.age);
      const timeDiff = Math.abs(Date.now() - convertAge.getTime());
      this.showAge = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365);
    }
  }
  private postPremium(e: any) {
    let params = new HttpParams();
    params = params.append('Age', this.showAge);
    params = params.append('SumInsured', this.registrationForm.get('SumInsured')?.value);
    params = params.append('OccupatioRating', e.target.value);
    
    this.httpPremiumService.getDeathPremium(params).subscribe(
      data =>{ 
        this.deathPremium=data;
      }
      );  
  }

  // Access formcontrols getter
  get OccupationType() {
    return this.registrationForm.get('OccupationType');
  }
  
}