import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { Dog } from './dog';

@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(private dogService: DogService) { }

  dogs: Dog[]
  dog: Dog = {
    id: 0,
    name: '',
    age: 0
  }
  dogName: string;
  dogAge: number;

  createDog() {
    this.dog.name = this.dogName;
    this.dog.age = +this.dogAge;
    console.log(this.dog);
    this.dogService.post(this.dog).subscribe(() => {
      this.dogService.get().subscribe(data => {
        this.dogs = data;
      });
    })
  }
  ngOnInit() {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    }

    )
  }

}
