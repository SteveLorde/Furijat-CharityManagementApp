import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';
import { FormsModule } from '@angular/forms';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'
import { MatTableDataSource } from '@angular/material/table';

export interface Student {
  name: string;
  subjects: string[];
  marks: number[];
  class: string;
  section: string;
}

const ELEMENT_DATA: Student[] = [
  {
    name: 'Tony',
    subjects: ['MATH', 'PHY', 'CHEM'],
    marks: [90, 95, 97],
    class: '12',
    section: 'A',
  },
  {
    name: 'Rita',
    subjects: ['MATH', 'PHY', 'BIO'],
    marks: [97, 92, 96],
    class: '12',
    section: 'A',
  },
  {
    name: 'Monty',
    subjects: ['MATH', 'PHY', 'BIO'],
    marks: [80, 99, 100],
    class: '12',
    section: 'B',
  },
  {
    name: 'Pintu',
    subjects: ['GEOLOGY', 'HISTORY'],
    marks: [90, 95],
    class: '12',
    section: 'C',
  },
  {
    name: 'Sarah',
    subjects: ['PAINTING', 'DANCE'],
    marks: [97, 100],
    class: '12',
    section: 'C',
  },
];


@Component({
  selector: 'app-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.css']
})
export class CaseListComponent implements OnInit {

  constructor(private _ServerCom: BackendCommunicationService) { }

  //declare an empty array for Case interface
  public Cases: any = [];
  public case = new Case();
  public CharityList: Charity[] = [];




  displayedColumns: string[] = ['name', 'class', 'section', 'subjects', 'marks',];

  columns = [
    {
      columnDef: 'name',
      header: 'Name',
      cell: (element: Student) => `${element.name}`,
    },
    {
      columnDef: 'class',
      header: 'Class',
      cell: (element: Student) => `${element.class}`,
    },
    {
      columnDef: 'section',
      header: 'Section',
      cell: (element: Student) => `${element.section}`,
    },
    {
      columnDef: 'subjects',
      header: 'Subjects',
      cell: (element: Student) => `${element.subjects.join(', ')}`,
    },
    {
      columnDef: 'marks',
      header: 'Marks',
      cell: (element: Student) => `${element.marks.join(', ')}`,
    },
  ];

  dataSource: MatTableDataSource<Student>;

  ngOnInit(): void {
    this.GetCases();
    this.dataSource = new MatTableDataSource(ELEMENT_DATA);
    //this.fetchStudents();
    this.dataSource.filterPredicate = this.filterBySubject();
  }

  //Function that calls API (GET) to retrieve Case List
  GetCases() {
    return this._ServerCom.getTEST().subscribe((data) => {
      this.Cases = data;
    });
  }
 
  //following functions are related to Table
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toUpperCase();
  }
  filterBySubject() {
    let filterFunction =
      (data: Student, filter: string): boolean => {
        if (filter) {
          const subjects = data.subjects;
          for (let i = 0; i < subjects.length; i++) {
            if (subjects[i].indexOf(filter) != -1) {
              return true;
            }
          }
          return false;
        } else {
          return true;
        }
      };
    return filterFunction;
  }
}

/*
 //test for pagination
 Students: any;
 allStudents: number = 0;
 pagination: number = 1;
 fetchStudents() {
   this._ServerCom.getStudents(this.pagination).subscribe((res: any) => {
     this.Students = res.data;
     this.allStudents = res.total;
     console.log(res.total);
   });
 }
 renderPage(event: number) {
   this.pagination = event;
   this.fetchStudents();
 }
 
 //function that calls API (POST) to create new cases in list
 PostCases() {
   return this._ServerCom.PostTest(this.case).subscribe()
 }
 */
