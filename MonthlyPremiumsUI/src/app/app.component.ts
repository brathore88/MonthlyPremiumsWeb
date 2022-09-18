import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isSubmitted = false;
  Occupations: any = ['Cleaner', 'Doctor', 'Author', 'Farmer', 'Mechanic', 'Florist'];
  constructor(public fb: FormBuilder) {}
  registrationForm = this.fb.group({
    OccupationType: ['', [Validators.required]],
  });
  changeOccupation(e: any) {
    this.OccupationType?.setValue(e.target.value, {
      onlySelf: true,
    });
    console.log(e.target.value);

  }
  // Access formcontrols getter
  get OccupationType() {
    return this.registrationForm.get('OccupationType');
  }
  onSubmit(): void {
    console.log(this.registrationForm);
    this.isSubmitted = true;
    if (!this.registrationForm.valid) {
      false;
    } else {
      console.log(JSON.stringify(this.registrationForm.value));
    }
  }
}