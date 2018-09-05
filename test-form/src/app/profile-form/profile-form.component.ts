import { Component } from '@angular/core';
import {Profile} from './profile';
import {ProfileService} from './profile-form.service'

@Component({
  selector: 'app-profile-form',
  templateUrl: './profile-form.component.html',
  styleUrls: ['./profile-form.component.css']
})
export class ProfileFormComponent {
  constructor(private profileService: ProfileService){};

  model = new Profile('', '');
  submitted = false;
  onSubmit() {
    this.profileService.addProfile(this.model).subscribe(data => {alert("Succesfully Added Profile"), this.submitted = true;}, Error => {alert("failed while adding profile")})
    ;
  }
}
