import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Job } from '../models/job.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = 'https://localhost:7013/api/jobs';
  constructor(private http: HttpClient) { }
  // get all jobs
  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.baseUrl);
  }
}
