import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'] 
})
export class HomeComponent {
    public isSearching: boolean = false;
    public search: PeopleSearch = { name: "" };
    public people: Person[];

    constructor(public http: Http) {    }

    public searchPeople() {
        this.isSearching = true;
        if (this.people != null) {
            this.people.length = 0;
        }
        var parms =  {
            name: this.search.name
        }
        var apiUrl = "http://localhost:49196/api/People/SearchByName";
        this.http.get(apiUrl, { search: parms }).subscribe(result => {
            this.people = result.json() as Person[];
            this.isSearching = false;
        },
            error => {
                console.error(error);
                this.isSearching = false;
            });
    }
    public getImageFullFilePath(image: string) {
        return "/images/" + image;
    }
}
interface PeopleSearch {
    name: string;
}
class Person {
    id: number;
    firstName: string;
    lastName: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    interests: string;
    age: string;
    profileImage: string;
}
