import { Component } from '@angular/core';
import { UsersService } from './services/users.service';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'JobPortal';

  constructor(private usersService: UsersService) {

  }
  ngOnInit(): void {
    this.getJobs();
  }
  getJobs() {
    this.usersService.getJobs().subscribe(response => { console.log(response); }, error => { console.log(error); });
  }
}
